#! /bin/sh

set -x

project="boat"
UNITY="${UNITY:-/applications/Unity/Unity.app/Contents/MacOS/Unity}"
LOGFILE="${LOGFILE:-$(pwd)/gh-pages/build.web.log}"

echo "Using unity executable: $UNITY"
echo "Log file: $LOGFILE"
echo "PWD: $(pwd)"

# Deploy dir
mkdir -p gh-pages
# Try to remove old log files
rm $LOGFILE 2> /dev/null
rm -rf gh-pages/index.html gh-pages/Build gh-pages/TemplateData

cp Assets/Editor/WebGLBuilder.cs .

# Web build
echo "Attempting to build $project for WebGL"
$UNITY \
	-quit \
	-batchmode \
	-nographics \
	-logFile $LOGFILE \
    -executeMethod WebGLBuilder.build

echo "Unity execution finished."
rm WebGLBuilder.cs
mv -f WebGL-Dist/index.html gh-pages
mv -f WebGL-Dist/Build gh-pages
mv -f WebGL-Dist/TemplateData gh-pages


#echo 'Attempting to zip builds'
#zip -r $(pwd)/Build/linux.zip $(pwd)/Build/linux/
#zip -r $(pwd)/Build/mac.zip $(pwd)/Build/osx/
#zip -r $(pwd)/Build/windows.zip $(pwd)/Build/windows/
