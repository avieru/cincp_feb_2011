$now = get-date
$new_branch_name = "$($now.year)$($now.month.tostring("00"))$($now.day.tostring("00"))$($now.hour.tostring("00"))$($now.minute.tostring("00"))"
git add -A
git commit -m "Committing"
git checkout master
git checkout -b $new_branch_name
git pull jp master
echo "new branch name:$new_branch_name"
