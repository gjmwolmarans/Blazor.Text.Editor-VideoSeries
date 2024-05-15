using BlazorTextEditor.ClassLib.TextEditor;
using Fluxor;
using System.Collections.Immutable;

namespace BlazorTextEditor.ClassLib.Store.TextEditorCase;

[FeatureState]
public record TextEditorStates(ImmutableDictionary<TextEditorKey, TextEditorBase> TextEditorMap)
{
    public TextEditorStates() : this(ImmutableDictionary<TextEditorKey, TextEditorBase>.Empty)
    {
    }
}