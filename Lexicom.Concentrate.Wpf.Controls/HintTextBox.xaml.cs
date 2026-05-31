using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Lexicom.Concentrate.Wpf.Controls;

public partial class HintTextBox : UserControl
{
    public HintTextBox()
    {
        InitializeComponent();

        InputBindings = [];
    }

    private InputBindingCollection? PreBindInputBindingCollection { get; set; }

    private TextBox? InputTextBox
    {
        get;
        set
        {
            field = value;
            SetInputTextBoxBinding(PreBindInputBindingCollection);
        }
    }

    #region lccBorder

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(HintTextBox), new PropertyMetadata(Border.CornerRadiusProperty.DefaultMetadata.DefaultValue));
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion

    #region lccHintTextBlock

    public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register(nameof(HintText), typeof(string), typeof(HintTextBox), new PropertyMetadata(string.Empty));
    public string? HintText
    {
        get => (string?)GetValue(HintTextProperty);
        set => SetValue(HintTextProperty, value);
    }

    public static readonly DependencyProperty HintForegroundProperty = DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(HintTextBox), new PropertyMetadata(ForegroundProperty.DefaultMetadata.DefaultValue));
    public Brush? HintForeground
    {
        get => (Brush?)GetValue(HintForegroundProperty);
        set => SetValue(HintForegroundProperty, value);
    }

    public static readonly DependencyProperty HintFlowDirectionProperty = DependencyProperty.Register(nameof(HintFlowDirection), typeof(FlowDirection), typeof(HintTextBox), new PropertyMetadata(FlowDirectionProperty.DefaultMetadata.DefaultValue));
    public FlowDirection HintFlowDirection
    {
        get => (FlowDirection)GetValue(HintFlowDirectionProperty);
        set => SetValue(HintFlowDirectionProperty, value);
    }

    public static readonly DependencyProperty HintFontFamilyProperty = DependencyProperty.Register(nameof(HintFontFamily), typeof(FontFamily), typeof(HintTextBox), new PropertyMetadata(FontFamilyProperty.DefaultMetadata.DefaultValue));
    public FontFamily? HintFontFamily
    {
        get => (FontFamily?)GetValue(HintFontFamilyProperty);
        set => SetValue(HintFontFamilyProperty, value);
    }

    public static readonly DependencyProperty HintFontSizeProperty = DependencyProperty.Register(nameof(HintFontSize), typeof(double), typeof(HintTextBox), new PropertyMetadata(FontSizeProperty.DefaultMetadata.DefaultValue));
    public double HintFontSize
    {
        get => (double)GetValue(HintFontSizeProperty);
        set => SetValue(HintFontSizeProperty, value);
    }

    public static readonly DependencyProperty HintFontStretchProperty = DependencyProperty.Register(nameof(HintFontStretch), typeof(FontStretch), typeof(HintTextBox), new PropertyMetadata(FontStretchProperty.DefaultMetadata.DefaultValue));
    public FontStretch HintFontStretch
    {
        get => (FontStretch)GetValue(HintFontStretchProperty);
        set => SetValue(HintFontStretchProperty, value);
    }

    public static readonly DependencyProperty HintFontStyleProperty = DependencyProperty.Register(nameof(HintFontStyle), typeof(FontStyle), typeof(HintTextBox), new PropertyMetadata(FontStyleProperty.DefaultMetadata.DefaultValue));
    public FontStyle HintFontStyle
    {
        get => (FontStyle)GetValue(HintFontStyleProperty);
        set => SetValue(HintFontStyleProperty, value);
    }

    public static readonly DependencyProperty HintFontWeightProperty = DependencyProperty.Register(nameof(HintFontWeight), typeof(FontWeight), typeof(HintTextBox), new PropertyMetadata(FontWeightProperty.DefaultMetadata.DefaultValue));
    public FontWeight HintFontWeight
    {
        get => (FontWeight)GetValue(HintFontWeightProperty);
        set => SetValue(HintFontWeightProperty, value);
    }

    public static readonly DependencyProperty HintHorizontalAlignmentProperty = DependencyProperty.Register(nameof(HintHorizontalAlignment), typeof(HorizontalAlignment), typeof(HintTextBox), new PropertyMetadata(HorizontalAlignment.Stretch));
    public HorizontalAlignment HintHorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(HintHorizontalAlignmentProperty);
        set => SetValue(HintHorizontalAlignmentProperty, value);
    }

    public static readonly DependencyProperty HintVerticalAlignmentProperty = DependencyProperty.Register(nameof(HintVerticalAlignment), typeof(VerticalAlignment), typeof(HintTextBox), new PropertyMetadata(VerticalAlignment.Center));
    public VerticalAlignment HintVerticalAlignment
    {
        get => (VerticalAlignment)GetValue(HintVerticalAlignmentProperty);
        set => SetValue(HintVerticalAlignmentProperty, value);
    }

    public static readonly DependencyProperty HintLineHeightProperty = DependencyProperty.Register(nameof(HintLineHeight), typeof(double), typeof(HintTextBox), new PropertyMetadata(TextBlock.LineHeightProperty.DefaultMetadata.DefaultValue));
    public double HintLineHeight
    {
        get => (double)GetValue(HintLineHeightProperty);
        set => SetValue(HintLineHeightProperty, value);
    }

    public static readonly DependencyProperty HintOpacityProperty = DependencyProperty.Register(nameof(HintOpacity), typeof(double), typeof(HintTextBox), new PropertyMetadata(OpacityProperty.DefaultMetadata.DefaultValue));
    public double HintOpacity
    {
        get => (double)GetValue(HintOpacityProperty);
        set => SetValue(HintOpacityProperty, value);
    }

    public static readonly DependencyProperty HintPaddingProperty = DependencyProperty.Register(nameof(HintPadding), typeof(Thickness), typeof(HintTextBox), new PropertyMetadata(PaddingProperty.DefaultMetadata.DefaultValue));
    public Thickness HintPadding
    {
        get => (Thickness)GetValue(HintPaddingProperty);
        set => SetValue(HintPaddingProperty, value);
    }

    public static readonly DependencyProperty HintTextAlignmentProperty = DependencyProperty.Register(nameof(HintTextAlignment), typeof(TextAlignment), typeof(HintTextBox), new PropertyMetadata(TextBlock.TextAlignmentProperty.DefaultMetadata.DefaultValue));
    public TextAlignment HintTextAlignment
    {
        get => (TextAlignment)GetValue(HintTextAlignmentProperty);
        set => SetValue(HintTextAlignmentProperty, value);
    }

    public static readonly DependencyProperty HintTextTrimmingProperty = DependencyProperty.Register(nameof(HintTextTrimming), typeof(TextTrimming), typeof(HintTextBox), new PropertyMetadata(TextBlock.TextTrimmingProperty.DefaultMetadata.DefaultValue));
    public TextTrimming HintTextTrimming
    {
        get => (TextTrimming)GetValue(HintTextTrimmingProperty);
        set => SetValue(HintTextTrimmingProperty, value);
    }

    public static readonly DependencyProperty HintTextWrappingProperty = DependencyProperty.Register(nameof(HintTextWrapping), typeof(TextWrapping), typeof(HintTextBox), new PropertyMetadata(TextBlock.TextWrappingProperty.DefaultMetadata.DefaultValue));
    public TextWrapping HintTextWrapping
    {
        get => (TextWrapping)GetValue(HintTextWrappingProperty);
        set => SetValue(HintTextWrappingProperty, value);
    }

    #endregion

    #region lccInputTextBox

    public static readonly DependencyProperty AcceptsReturnProperty = DependencyProperty.Register(nameof(AcceptsReturn), typeof(bool), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.AcceptsReturnProperty.DefaultMetadata.DefaultValue));
    public bool AcceptsReturn
    {
        get => (bool)GetValue(AcceptsReturnProperty);
        set => SetValue(AcceptsReturnProperty, value);
    }

    public static readonly DependencyProperty AcceptsTabProperty = DependencyProperty.Register(nameof(AcceptsTab), typeof(bool), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.AcceptsTabProperty.DefaultMetadata.DefaultValue));
    public bool AcceptsTab
    {
        get => (bool)GetValue(AcceptsTabProperty);
        set => SetValue(AcceptsTabProperty, value);
    }

    public static readonly DependencyProperty CaretBrushProperty = DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.CaretBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? CaretBrush
    {
        get => (Brush?)GetValue(CaretBrushProperty);
        set => SetValue(CaretBrushProperty, value);
    }

    public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.Register(nameof(CharacterCasing), typeof(CharacterCasing), typeof(HintTextBox), new PropertyMetadata(TextBox.CharacterCasingProperty.DefaultMetadata.DefaultValue));
    public CharacterCasing CharacterCasing
    {
        get => (CharacterCasing)GetValue(CharacterCasingProperty);
        set => SetValue(CharacterCasingProperty, value);
    }

    public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = DependencyProperty.Register(nameof(HorizontalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(HintTextBox), new PropertyMetadata(ScrollBarVisibility.Hidden));
    public ScrollBarVisibility HorizontalScrollBarVisibility
    {
        get => (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty);
        set => SetValue(HorizontalScrollBarVisibilityProperty, value);
    }

    public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.IsReadOnlyProperty.DefaultMetadata.DefaultValue));
    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    public static readonly DependencyProperty IsInactiveSelectionHighlightEnabledProperty = DependencyProperty.Register(nameof(IsInactiveSelectionHighlightEnabled), typeof(bool), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.IsInactiveSelectionHighlightEnabledProperty.DefaultMetadata.DefaultValue));
    public bool IsInactiveSelectionHighlightEnabled
    {
        get => (bool)GetValue(IsInactiveSelectionHighlightEnabledProperty);
        set => SetValue(IsInactiveSelectionHighlightEnabledProperty, value);
    }

    public static readonly DependencyProperty IsReadOnlyCaretVisibleProperty = DependencyProperty.Register(nameof(IsReadOnlyCaretVisible), typeof(bool), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.IsReadOnlyCaretVisibleProperty.DefaultMetadata.DefaultValue));
    public bool IsReadOnlyCaretVisible
    {
        get => (bool)GetValue(IsReadOnlyCaretVisibleProperty);
        set => SetValue(IsReadOnlyCaretVisibleProperty, value);
    }

    public static readonly DependencyProperty IsUndoEnabledProperty = DependencyProperty.Register(nameof(IsUndoEnabled), typeof(bool), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.IsUndoEnabledProperty.DefaultMetadata.DefaultValue));
    public bool IsUndoEnabled
    {
        get => (bool)GetValue(IsUndoEnabledProperty);
        set => SetValue(IsUndoEnabledProperty, value);
    }

    public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(nameof(MaxLength), typeof(int), typeof(HintTextBox), new PropertyMetadata(TextBox.MaxLengthProperty.DefaultMetadata.DefaultValue));
    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    public static readonly DependencyProperty MaxLinesProperty = DependencyProperty.Register(nameof(MaxLines), typeof(int), typeof(HintTextBox), new PropertyMetadata(TextBox.MaxLinesProperty.DefaultMetadata.DefaultValue));
    public int MaxLines
    {
        get => (int)GetValue(MaxLinesProperty);
        set => SetValue(MaxLinesProperty, value);
    }

    public static readonly DependencyProperty MinLinesProperty = DependencyProperty.Register(nameof(MinLines), typeof(int), typeof(HintTextBox), new PropertyMetadata(TextBox.MinLinesProperty.DefaultMetadata.DefaultValue));
    public int MinLines
    {
        get => (int)GetValue(MinLinesProperty);
        set => SetValue(MinLinesProperty, value);
    }

    public static readonly DependencyProperty SelectionBrushProperty = DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.SelectionBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? SelectionBrush
    {
        get => (Brush?)GetValue(SelectionBrushProperty);
        set => SetValue(SelectionBrushProperty, value);
    }

    public static readonly DependencyProperty SelectionOpacityProperty = DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.SelectionOpacityProperty.DefaultMetadata.DefaultValue));
    public double SelectionOpacity
    {
        get => (double)GetValue(SelectionOpacityProperty);
        set => SetValue(SelectionOpacityProperty, value);
    }

    public static readonly DependencyProperty SelectionTextBrushProperty = DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.SelectionTextBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? SelectionTextBrush
    {
        get => (Brush?)GetValue(SelectionTextBrushProperty);
        set => SetValue(SelectionTextBrushProperty, value);
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(HintTextBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public string? Text
    {
        get => (string?)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(HintTextBox), new PropertyMetadata(TextBox.TextAlignmentProperty.DefaultMetadata.DefaultValue));
    public TextAlignment TextAlignment
    {
        get => (TextAlignment)GetValue(TextAlignmentProperty);
        set => SetValue(TextAlignmentProperty, value);
    }

    public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(nameof(TextWrapping), typeof(TextWrapping), typeof(HintTextBox), new PropertyMetadata(TextBox.TextWrappingProperty.DefaultMetadata.DefaultValue));
    public TextWrapping TextWrapping
    {
        get => (TextWrapping)GetValue(TextWrappingProperty);
        set => SetValue(TextWrappingProperty, value);
    }

    public static readonly DependencyProperty UndoLimitProperty = DependencyProperty.Register(nameof(UndoLimit), typeof(int), typeof(HintTextBox), new PropertyMetadata(TextBoxBase.UndoLimitProperty.DefaultMetadata.DefaultValue));
    public int UndoLimit
    {
        get => (int)GetValue(UndoLimitProperty);
        set => SetValue(UndoLimitProperty, value);
    }

    public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = DependencyProperty.Register(nameof(VerticalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(HintTextBox), new PropertyMetadata(ScrollBarVisibility.Hidden));
    public ScrollBarVisibility VerticalScrollBarVisibility
    {
        get => (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty);
        set => SetValue(VerticalScrollBarVisibilityProperty, value);
    }

    public static readonly DependencyProperty InputBindingsProperty = DependencyProperty.Register(nameof(InputBindings), typeof(InputBindingCollection), typeof(HintTextBox), new FrameworkPropertyMetadata(null, OnInputBindings_PropertyChanged));
    public new InputBindingCollection? InputBindings
    {
        get => (InputBindingCollection?)GetValue(InputBindingsProperty);
        set => SetValue(InputBindingsProperty, value);
    }
    private static void OnInputBindings_PropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
    {
        if (sender is not null and HintTextBox hintTextBox)
        {
            hintTextBox.SetInputTextBoxBinding((InputBindingCollection?)args.NewValue);
        }
    }

    #endregion

    public new static readonly DependencyProperty IsFocusedProperty = DependencyProperty.Register(nameof(IsFocused), typeof(bool), typeof(HintTextBox), new PropertyMetadata(false));
    public new bool IsFocused
    {
        get => (bool)GetValue(IsFocusedProperty);
        private set => SetValue(IsFocusedProperty, value);
    }

    private void SetInputTextBoxBinding(InputBindingCollection? inputBindingCollection)
    {
        PreBindInputBindingCollection = inputBindingCollection;
        if (InputTextBox is not null && PreBindInputBindingCollection is not null)
        {
            InputTextBox.InputBindings?.Clear();
            InputTextBox.InputBindings?.AddRange(PreBindInputBindingCollection);
        }
    }

    private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        IsFocused = true;
    }

    private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        IsFocused = false;
    }

    private void InputTextBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox senderTextBox)
        {
            InputTextBox = senderTextBox;
        }
    }
}
