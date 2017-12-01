#! /bin/sh

project="boat"

echo "Attempting to build $project for WebGL"
/applications/Unity/Unity.app/Contents/MacOS/Unity
	-quit 
	-batchmode 
	-nograhpics
	-silent-crashes
	-logFile $(pwd)/build.web.log
	-executeMethod $(pwd)/Assets/Editor/WebGLBuilder.build

echo 'Logs from build'
cat $(pwd)/gh-pages/build.web.log


#echo 'Attempting to zip builds'
#zip -r $(pwd)/Build/linux.zip $(pwd)/Build/linux/
#zip -r $(pwd)/Build/mac.zip $(pwd)/Build/osx/
#zip -r $(pwd)/Build/windows.zip $(pwd)/Build/windows/
echo `git status -u`
