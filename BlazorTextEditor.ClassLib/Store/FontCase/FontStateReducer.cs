using Fluxor;

namespace BlazorTextEditor.ClassLib.Store.FontCase;

public class FontStateReducer
{
    [ReducerMethod]
    public static FontState ReduceSetFontSizeInPixelsAction(FontState previousFontState,
        SetFontSizeInPixelsAction setFontSizeInPixelsAction)
    {
        return previousFontState with
        {
            FontSizeInPixels = setFontSizeInPixelsAction.FontSizeInPixels
        };
    }
}