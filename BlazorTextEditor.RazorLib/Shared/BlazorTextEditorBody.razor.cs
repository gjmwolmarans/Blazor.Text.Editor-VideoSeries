using BlazorTextEditor.ClassLib.Dimensions;
using Microsoft.AspNetCore.Components;

namespace BlazorTextEditor.RazorLib.Shared;

public partial class BlazorTextEditorBody : ComponentBase
{
    [Parameter, EditorRequired]
    public ElementDimensions BodyElementDimensions { get; set; } = null!;
    
    private ElementDimensions _folderExplorerElementDimensions = new();
    private ElementDimensions _editorElementDimensions = new();

    protected override void OnInitialized()
    {
        var folderExplorerWidth = _folderExplorerElementDimensions.DimensionAttributes
            .Single(da => da.DimensionAttributeKind == DimensionAttributeKind.Width);
        
        folderExplorerWidth.DimensionUnits.AddRange(new []
        {
            new DimensionUnit
            {
                Value = 30,
                DimensionUnitKind = DimensionUnitKind.Percentage
            },
            new DimensionUnit
            {
                Value = 2.5,
                DimensionUnitKind = DimensionUnitKind.Pixels,
                DimensionOperatorKind = DimensionOperatorKind.Subtract
            }
        });

        var editorWidth = _editorElementDimensions.DimensionAttributes
            .Single(da => da.DimensionAttributeKind == DimensionAttributeKind.Width);
        
        editorWidth.DimensionUnits.AddRange(new []
        {
            new DimensionUnit
            {
                Value = 70,
                DimensionUnitKind = DimensionUnitKind.Percentage
            },
            new DimensionUnit
            {
                Value = 2.5,
                DimensionUnitKind = DimensionUnitKind.Pixels,
                DimensionOperatorKind = DimensionOperatorKind.Subtract
            }
        });
        
        base.OnInitialized();
    }

    private async Task ReRenderAsync()
    {
        await InvokeAsync(StateHasChanged);
    }
}