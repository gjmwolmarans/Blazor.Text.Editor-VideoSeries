using BlazorTextEditor.ClassLib.Dropdown;
using BlazorTextEditor.ClassLib.Store.DropdownCase;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorTextEditor.RazorLib.Dropdown;

public partial class DropdownDisplay : FluxorComponent
{
    [Inject]
    private IState<DropdownStates> DropdownStatesWrap { get; set; } = null!;
    [Inject]
    private IDispatcher Dispatcher { get; set; } = null!;
    
    [Parameter, EditorRequired]
    public DropdownKey DropdownKey { get; set; } = null!;
    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;
    [Parameter, EditorRequired]
    public DropdownPositionKind DropdownPositionKind { get; set; } = DropdownPositionKind.Vertical;

    private bool ShouldDisplay => DropdownStatesWrap.Value.ActiveDropdownKeys
        .Contains(DropdownKey);
    
    private string DropdownPositionKindStyleCss => DropdownPositionKind switch
    {
        DropdownPositionKind.Vertical => "position: absolute; left: 0; top: 100%;",
        DropdownPositionKind.Horizontal => "position: absolute; left: 100%; top: 0;",
        DropdownPositionKind.Unset => string.Empty,
        _ => throw new ApplicationException($"The {nameof(DropdownPositionKind)}: {DropdownPositionKind} was unrecognized.") 
    };

    protected override void Dispose(bool disposing)
    {
        if (ShouldDisplay)
            Dispatcher.Dispatch(new RemoveActiveDropdownKeyAction(DropdownKey));
        
        base.Dispose(disposing);
    }

    private void ClearAllActiveDropdownKeys(MouseEventArgs mouseEventArgs)
    {
        Dispatcher.Dispatch(new ClearActiveDropdownKeysAction());
    }
}


