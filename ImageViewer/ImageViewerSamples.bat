:: ImageViewerVolume specific postbuild step

call "..\..\..\..\ImageViewer\ImageViewer.bat" %1

echo Executing ImageViewerVolume post-build step

copy "..\..\..\..\ImageViewer\Samples\WebBrowser\bin\%1\ClearCanvas.ImageViewer.Samples.WebBrowser.dll" ".\plugins"
copy "..\..\..\..\ImageViewer\Samples\WebBrowser\View\WinForms\bin\%1\ClearCanvas.ImageViewer.Samples.WebBrowser.View.WinForms.dll" ".\plugins"
