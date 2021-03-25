$ProjectRootDir = "$PSScriptRoot/../"
# プロジェクトのディレクトリへ移動
Push-Location $ProjectRootDir
# フォーマット
jb cleanupcode --exclude="**/*.xaml" .\ColorSelectPrompt.sln
# 元のディレクトリへ
Pop-Location
