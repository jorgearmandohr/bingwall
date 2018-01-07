// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace bingwall
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSImageCell imgWallpaper { get; set; }

        [Outlet]
        AppKit.NSTextFieldCell lblInfo { get; set; }

        [Outlet]
        AppKit.NSTextField lblPictureDate { get; set; }

        [Action ("btnApply:")]
        partial void btnApply (AppKit.NSButton sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (imgWallpaper != null) {
                imgWallpaper.Dispose ();
                imgWallpaper = null;
            }

            if (lblInfo != null) {
                lblInfo.Dispose ();
                lblInfo = null;
            }

            if (lblPictureDate != null) {
                lblPictureDate.Dispose ();
                lblPictureDate = null;
            }
        }
    }
}
