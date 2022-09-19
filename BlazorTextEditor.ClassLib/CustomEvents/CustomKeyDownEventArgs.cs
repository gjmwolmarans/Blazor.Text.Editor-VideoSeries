namespace BlazorTextEditor.ClassLib.CustomEvents;

public class CustomKeyDownEventArgs : EventArgs
{
    public string Key { get; set; }
    public string Code { get; set; }
    public bool CtrlWasPressed { get; set; }
    public bool ShiftWasPressed { get; set; }
    public bool AltWasPressed { get; set; }
}