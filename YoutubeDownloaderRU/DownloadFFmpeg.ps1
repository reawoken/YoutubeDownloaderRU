$ErrorActionPreference = "Stop"
$sourcePath = "$PSScriptRoot/ffmpeg.exe"
$ffmpegFilePath = "$PSScriptRoot/ffmpeg.exe"  # Указываем путь, куда нужно скопировать ffmpeg.exe

# Проверяем, существует ли ffmpeg.exe в папке со скриптом
if (-not (Test-Path $sourcePath)) {
    Write-Host "Файл ffmpeg.exe не найден в папке со скриптом."
    exit
}

# Проверяем, существует ли уже файл в конечном месте назначения
if (Test-Path $ffmpegFilePath) {
    Write-Host "Skipped copying FFmpeg, file already exists."
    exit
}

# Копируем файл
Copy-Item -Path $sourcePath -Destination $ffmpegFilePath -Force

Write-Host "Файл ffmpeg.exe успешно скопирован."