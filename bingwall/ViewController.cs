using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using AppKit;
using Foundation;

namespace bingwall
{
    public partial class ViewController : NSViewController
    {
        private string url; 
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            WallpaperService wallpaper = new WallpaperService();
            var model = wallpaper.GetTodayWallpaperUrl();
            var stream = wallpaper.GetStream(model.Url);
            imgWallpaper.Image = NSImage.FromStream(stream);
            url = model.Url;
            lblInfo.StringValue = model.Copyright;
            lblPictureDate.StringValue = model.Startdate;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void btnApply(AppKit.NSButton sender)
        {
            string pictureName = $"bing_wallpaper_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.jpg";
            WallpaperService wallpaper = new WallpaperService();
            var data = wallpaper.GetByte(url);
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            File.WriteAllBytes(Path.Combine(path, pictureName), data);

            var fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/" + pictureName;
            var cmd = $"tell application \"Finder\" to set desktop picture to \"{fileName}\" as POSIX file";
            using (var script = new NSAppleScript(cmd))
            {
                var errors = new NSDictionary();
                var result = script.ExecuteAndReturnError(out errors);
                //if (!string.IsNullOrEmpty(errors.Val))
                //{

                //}
            }


        }

        private void AddToStart()
        {
            //osascript -e 'tell application "System Events" to make login item at end with properties {path:"/path/to/itemname", hidden:false}' 
        }

        private void RemoveFromStart()
        {
            //osascript -e 'tell application "System Events" to delete login item "itemname"' 
        }
    }
}
