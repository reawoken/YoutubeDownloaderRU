﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Stylet;

namespace YoutubeDownloaderRU.ViewModels.Framework;

public class DialogManager(IViewManager viewManager) : IDisposable
{
    private readonly SemaphoreSlim _dialogLock = new(1, 1);

    public async ValueTask<T?> ShowDialogAsync<T>(DialogScreen<T> dialogScreen)
    {
        var view = viewManager.CreateAndBindViewForModelIfNecessary(dialogScreen);

        void OnDialogOpened(object? openSender, DialogOpenedEventArgs openArgs)
        {
            void OnScreenClosed(object? closeSender, EventArgs closeArgs)
            {
                try
                {
                    openArgs.Session.Close();
                }
                catch (InvalidOperationException)
                {
                    // Race condition: dialog is already being closed
                }

                dialogScreen.Closed -= OnScreenClosed;
            }

            dialogScreen.Closed += OnScreenClosed;
        }

        await _dialogLock.WaitAsync();
        try
        {
            await DialogHost.Show(view, OnDialogOpened);
            return dialogScreen.DialogResult;
        }
        finally
        {
            _dialogLock.Release();
        }
    }

    public string? PromptSaveFilePath(string filter = "All files|*.*", string defaultFilePath = "")
    {
        var dialog = new SaveFileDialog
        {
            Filter = filter,
            AddExtension = true,
            FileName = defaultFilePath,
            DefaultExt = Path.GetExtension(defaultFilePath)
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }

    public string? PromptDirectoryPath(string defaultDirPath = "")
    {
        var dialog = new OpenFolderDialog { InitialDirectory = defaultDirPath };
        return dialog.ShowDialog() == true ? dialog.FolderName : null;
    }

    public void Dispose()
    {
        _dialogLock.Dispose();
    }
}
