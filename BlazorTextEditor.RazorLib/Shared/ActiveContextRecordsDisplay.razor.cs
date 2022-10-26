using BlazorTextEditor.ClassLib.Store.ContextCase;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorTextEditor.RazorLib.Shared;

public partial class ActiveContextRecordsDisplay : FluxorComponent
{
    [Inject]
    private IState<ContextStates> ContextStatesWrap { get; set; } = null!;
}