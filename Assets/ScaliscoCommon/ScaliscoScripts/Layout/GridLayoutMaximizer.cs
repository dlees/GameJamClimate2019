using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

/// <summary>
/// Configures a <see cref="GridLayoutGroup.cellSize"/> on same GameObject to have
/// maximum size for the specified number of rows or columns.
/// By default, it uses the number from the constraint configured in the <see cref="GridLayoutGroup"/>.
/// Use the 'override' values here to override or specify a size
/// when <see cref="GridLayoutGroup.Constraint.Flexible"/> used.
/// 
/// From https://forum.unity.com/threads/flexible-grid-layout.296074/
/// </summary>
public sealed class GridLayoutMaximizer : MonoBehaviour {

    [Tooltip("Override the number of columns to aim for (or zero for default/disabled).\n" +
            "Takes priority over rows.")]
    [SerializeField]
    private int numColumnsOverride = 0;

    [Tooltip("Override the number of rows to aim for (or zero for default/disabled).")]
    [SerializeField]
    private int numRowsOverride = 0;

    public RectTransform transformToBaseSizeOn;

    public void OnValidate() {
        Assert.IsNotNull(transform as RectTransform);
        Assert.IsNotNull(GetComponent<GridLayoutGroup>());
    }

    public void OnEnable() {
        if (transformToBaseSizeOn == null) {
            transformToBaseSizeOn = (RectTransform)transform;
        }
        setSizes();
    }

    public void OnTransformChildrenChanged() {
        if (transformToBaseSizeOn == null) {
            transformToBaseSizeOn = (RectTransform)transform;
        }
        setSizes();

    }

    [ContextMenu("Set sizes")]
    private void setSizes() {
        var gridLayoutGroup = GetComponent<GridLayoutGroup>();
        var maxColumnCount = this.numColumnsOverride;
        var maxRowCount = this.numRowsOverride;
        switch (gridLayoutGroup.constraint) {
            case GridLayoutGroup.Constraint.Flexible: // nop
                break;

            case GridLayoutGroup.Constraint.FixedColumnCount:
                maxColumnCount = gridLayoutGroup.constraintCount;
                break;

            case GridLayoutGroup.Constraint.FixedRowCount:
                maxRowCount = gridLayoutGroup.constraintCount;
                break;

            default:
                throw new ArgumentOutOfRangeException(gridLayoutGroup.constraint.ToString());
        }

        var padding = gridLayoutGroup.padding;
        var spacing = gridLayoutGroup.spacing;
        var size = transformToBaseSizeOn.rect.size - new Vector2(padding.horizontal, padding.vertical);

        float width = gridLayoutGroup.cellSize.x, height = gridLayoutGroup.cellSize.y;
        
        // override cell size based on column/row count
        if (0 < maxColumnCount) {
            width = (size.x - (maxColumnCount - 1) * spacing.x) / maxColumnCount;
            if (0 < maxRowCount) {
                height = (size.y - (maxRowCount - 1) * spacing.y) / maxRowCount;
            } else {
                // TODO: account for different vertical to horizontal spacing
            }
        } else if (0 < maxRowCount) { // rows specified but not columns
           // TODO: account for different vertical to horizontal spacing
            width = height = (size.y - (maxRowCount - 1) * spacing.y) / maxRowCount;

        } else { // neither specified
            return;
        }

        gridLayoutGroup.cellSize = new Vector2(width, height);
    }

}