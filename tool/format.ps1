$ProjectRootDir = "$PSScriptRoot/../"
# プロジェクトのディレクトリへ移動
Push-Location $ProjectRootDir
# フォーマット
jb cleanupcode --exclude="**/*.xaml" .\ChoiceMenuPrompt.sln
# 元のディレクトリへ
Pop-Location
