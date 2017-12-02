#! /bin/sh

set -x

project="boat"

rm $(pwd)/gh-pages/build.web.log 2> /dev/null

echo "Attempting to build $project for WebGL"
/applications/Unity/Unity.app/Contents/MacOS/Unity
	-quit 
	-batchmode 
	-nograhpics
	-silent-crashes
        -executeMethod $(pwd)/Assets/Editor/WebGLBuilder.build 2>&1 | tee $(pwd)/gh-pages/build.web.log

echo 'Logs from build'
cat $(pwd)/gh-pages/build.web.log


#echo 'Attempting to zip builds'
#zip -r $(pwd)/Build/linux.zip $(pwd)/Build/linux/
#zip -r $(pwd)/Build/mac.zip $(pwd)/Build/osx/
#zip -r $(pwd)/Build/windows.zip $(pwd)/Build/windows/
echo `git status -u`
