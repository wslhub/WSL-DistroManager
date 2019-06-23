namespace WslManager.Interop
{
    // https://stackoverflow.com/questions/12925748/iapplicationactivationmanageractivateapplication-in-c
    public enum ActivateOptions : uint
    {
        None = 0x00000000,  // No flags set
        DesignMode = 0x00000001,  // The application is being activated for design mode, and thus will not be able to
                                  // to create an immersive window. Window creation must be done by design tools which
                                  // load the necessary components by communicating with a designer-specified service on
                                  // the site chain established on the activation manager.  The splash screen normally
                                  // shown when an application is activated will also not appear.  Most activations
                                  // will not use this flag.
        NoErrorUI = 0x00000002,  // Do not show an error dialog if the app fails to activate.                                
        NoSplashScreen = 0x00000004,  // Do not show the splash screen when activating the app.
    }
}
