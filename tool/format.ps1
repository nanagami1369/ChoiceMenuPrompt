$ProjectRootDir = "$PSScriptRoot/../"
# プロジェクトのディレクトリへ移動
Push-Location $ProjectRootDir
# フォーマット
$slnFile = Get-Item *.sln
jb cleanupcode --exclude="**/*.xaml" $slnFile
# 元のディレクトリへ
Pop-Location
