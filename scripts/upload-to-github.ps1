# Run this script from the project root in PowerShell
# It will initialize git (if needed), create an initial commit and push to GitHub.
# Replace or confirm the remote URL below matches your repository.

$remote = 'https://github.com/so489/lost-and-found.git'

if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Write-Error "Git is not installed or not on PATH. Install Git and re-run this script."
    exit 1
}

if (-not (Test-Path .git)) {
    git init
    Write-Host "Initialized empty git repository."
} else {
    Write-Host "Existing git repository detected."
}

git add .

# Avoid failing if there is nothing to commit
try {
    git commit -m "Initial commit" -q
    Write-Host "Committed files."
} catch {
    Write-Host "No changes to commit or commit failed. Continuing..."
}

# Add or set remote
$existing = git remote | Select-String -Pattern '^origin$' -Quiet
if ($existing) {
    git remote remove origin
}

git remote add origin $remote
Write-Host "Remote 'origin' set to $remote"

# Ensure main branch
try {
    git branch -M main
} catch {
    # older git may not support -M; ignore
}

Write-Host "About to push to GitHub. You will be prompted for credentials if required."
Write-Host "If you prefer SSH auth, set the remote to git@github.com:so489/lost-and-found.git instead."

git push -u origin main

Write-Host "Done. Check https://github.com/so489/lost-and-found to confirm the repository." 
