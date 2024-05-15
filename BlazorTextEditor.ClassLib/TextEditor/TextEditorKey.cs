using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTextEditor.ClassLib.TextEditor;

public record TextEditorKey(Guid textEditorKey)
{
    public static TextEditorKey NewTextEditorKey()
    {
        return new TextEditorKey(Guid.NewGuid());
    }
}
