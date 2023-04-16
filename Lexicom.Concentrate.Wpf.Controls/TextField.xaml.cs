using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Lexicom.Concentrate.Wpf.Controls;
public partial class TextField : UserControl
{
    public TextField() => InitializeComponent();

    private InputBindingCollection? PreBindInputBindingCollection { get; set; }

    private TextBox? _valueTextBox;
    private TextBox? ValueTextBox
    {
        get => _valueTextBox;
        set
        {
            _valueTextBox = value;
            SetInputTextBoxBinding(PreBindInputBindingCollection);
        }
    }

    #region ccBorder

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(TextField), new PropertyMetadata(Border.CornerRadiusProperty.DefaultMetadata.DefaultValue));
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion

    #region ccKeyBorder

    public static readonly DependencyProperty KeyBackgroundProperty = DependencyProperty.Register(nameof(KeyBackground), typeof(Brush), typeof(TextField), new PropertyMetadata(BackgroundProperty.DefaultMetadata.DefaultValue));
    public Brush? KeyBackground
    {
        get => (Brush?)GetValue(KeyBackgroundProperty);
        set => SetValue(KeyBackgroundProperty, value);
    }

    public static readonly DependencyProperty KeyBorderBrushProperty = DependencyProperty.Register(nameof(KeyBorderBrush), typeof(Brush), typeof(TextField), new PropertyMetadata(BorderBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? KeyBorderBrush
    {
        get => (Brush?)GetValue(KeyBorderBrushProperty);
        set => SetValue(KeyBorderBrushProperty, value);
    }

    public static readonly DependencyProperty KeyBorderThicknessProperty = DependencyProperty.Register(nameof(KeyBorderThickness), typeof(Thickness), typeof(TextField), new PropertyMetadata(BorderThicknessProperty.DefaultMetadata.DefaultValue));
    public Thickness KeyBorderThickness
    {
        get => (Thickness)GetValue(KeyBorderThicknessProperty);
        set => SetValue(KeyBorderThicknessProperty, value);
    }

    public static readonly DependencyProperty KeyCornerRadiusProperty = DependencyProperty.Register(nameof(KeyCornerRadius), typeof(CornerRadius), typeof(TextField), new PropertyMetadata(Border.CornerRadiusProperty.DefaultMetadata.DefaultValue));
    public CornerRadius KeyCornerRadius
    {
        get => (CornerRadius)GetValue(KeyCornerRadiusProperty);
        set => SetValue(KeyCornerRadiusProperty, value);
    }

    public static readonly DependencyProperty KeyOpacityProperty = DependencyProperty.Register(nameof(KeyOpacity), typeof(double), typeof(TextField), new PropertyMetadata(OpacityProperty.DefaultMetadata.DefaultValue));
    public double KeyOpacity
    {
        get => (double)GetValue(KeyOpacityProperty);
        set => SetValue(KeyOpacityProperty, value);
    }

    public static readonly DependencyProperty KeyPaddingProperty = DependencyProperty.Register(nameof(KeyPadding), typeof(Thickness), typeof(TextField), new PropertyMetadata(PaddingProperty.DefaultMetadata.DefaultValue));
    public Thickness KeyPadding
    {
        get => (Thickness)GetValue(KeyPaddingProperty);
        set => SetValue(KeyPaddingProperty, value);
    }

    public static readonly DependencyProperty KeyVisiblityProperty = DependencyProperty.Register(nameof(KeyVisiblity), typeof(Visibility), typeof(TextField), new PropertyMetadata(VisibilityProperty.DefaultMetadata.DefaultValue));
    public Visibility KeyVisiblity
    {
        get => (Visibility)GetValue(KeyVisiblityProperty);
        set => SetValue(KeyVisiblityProperty, value);
    }

    public static readonly DependencyProperty KeyWidthProperty = DependencyProperty.Register(nameof(KeyWidth), typeof(double), typeof(TextField), new PropertyMetadata(double.NaN));
    public double KeyWidth
    {
        get => (double)GetValue(KeyWidthProperty);
        set => SetValue(KeyWidthProperty, value);
    }

    public static readonly DependencyProperty KeyMinWidthProperty = DependencyProperty.Register(nameof(KeyMinWidth), typeof(double), typeof(TextField), new PropertyMetadata(MinWidthProperty.DefaultMetadata.DefaultValue));
    public double KeyMinWidth
    {
        get => (double)GetValue(KeyMinWidthProperty);
        set => SetValue(KeyMinWidthProperty, value);
    }

    public static readonly DependencyProperty KeyMaxWidthProperty = DependencyProperty.Register(nameof(KeyMaxWidth), typeof(double), typeof(TextField), new PropertyMetadata(MaxWidthProperty.DefaultMetadata.DefaultValue));
    public double KeyMaxWidth
    {
        get => (double)GetValue(KeyMaxWidthProperty);
        set => SetValue(KeyMaxWidthProperty, value);
    }

    #endregion

    #region ccKeyLabel

    public static readonly DependencyProperty KeyFlowDirectionProperty = DependencyProperty.Register(nameof(KeyFlowDirection), typeof(FlowDirection), typeof(TextField), new PropertyMetadata(FlowDirectionProperty.DefaultMetadata.DefaultValue));
    public FlowDirection KeyFlowDirection
    {
        get => (FlowDirection)GetValue(KeyFlowDirectionProperty);
        set => SetValue(KeyFlowDirectionProperty, value);
    }

    public static readonly DependencyProperty KeyFontFamilyProperty = DependencyProperty.Register(nameof(KeyFontFamily), typeof(FontFamily), typeof(TextField), new PropertyMetadata(FontFamilyProperty.DefaultMetadata.DefaultValue));
    public FontFamily? KeyFontFamily
    {
        get => (FontFamily?)GetValue(KeyFontFamilyProperty);
        set => SetValue(KeyFontFamilyProperty, value);
    }

    public static readonly DependencyProperty KeyFontSizeProperty = DependencyProperty.Register(nameof(KeyFontSize), typeof(double), typeof(TextField), new PropertyMetadata(FontSizeProperty.DefaultMetadata.DefaultValue));
    public double KeyFontSize
    {
        get => (double)GetValue(KeyFontSizeProperty);
        set => SetValue(KeyFontSizeProperty, value);
    }

    public static readonly DependencyProperty KeyFontStretchProperty = DependencyProperty.Register(nameof(KeyFontStretch), typeof(FontStretch), typeof(TextField), new PropertyMetadata(FontStretchProperty.DefaultMetadata.DefaultValue));
    public FontStretch KeyFontStretch
    {
        get => (FontStretch)GetValue(KeyFontStretchProperty);
        set => SetValue(KeyFontStretchProperty, value);
    }

    public static readonly DependencyProperty KeyFontStyleProperty = DependencyProperty.Register(nameof(KeyFontStyle), typeof(FontStyle), typeof(TextField), new PropertyMetadata(FontStyleProperty.DefaultMetadata.DefaultValue));
    public FontStyle KeyFontStyle
    {
        get => (FontStyle)GetValue(KeyFontStyleProperty);
        set => SetValue(KeyFontStyleProperty, value);
    }

    public static readonly DependencyProperty KeyFontWeightProperty = DependencyProperty.Register(nameof(KeyFontWeight), typeof(FontWeight), typeof(TextField), new PropertyMetadata(FontWeightProperty.DefaultMetadata.DefaultValue));
    public FontWeight KeyFontWeight
    {
        get => (FontWeight)GetValue(KeyFontWeightProperty);
        set => SetValue(KeyFontWeightProperty, value);
    }

    public static readonly DependencyProperty KeyForegroundProperty = DependencyProperty.Register(nameof(KeyForeground), typeof(Brush), typeof(TextField), new PropertyMetadata(ForegroundProperty.DefaultMetadata.DefaultValue));
    public Brush? KeyForeground
    {
        get => (Brush?)GetValue(KeyForegroundProperty);
        set => SetValue(KeyForegroundProperty, value);
    }

    public static readonly DependencyProperty KeyHorizontalContentAlignmentProperty = DependencyProperty.Register(nameof(KeyHorizontalContentAlignment), typeof(HorizontalAlignment), typeof(TextField), new PropertyMetadata(HorizontalContentAlignmentProperty.DefaultMetadata.DefaultValue));
    public HorizontalAlignment KeyHorizontalContentAlignment
    {
        get => (HorizontalAlignment)GetValue(KeyHorizontalContentAlignmentProperty);
        set => SetValue(KeyHorizontalContentAlignmentProperty, value);
    }

    public static readonly DependencyProperty KeyVerticalContentAlignmentProperty = DependencyProperty.Register(nameof(KeyVerticalContentAlignment), typeof(VerticalAlignment), typeof(TextField), new PropertyMetadata(VerticalAlignment.Center));
    public VerticalAlignment KeyVerticalContentAlignment
    {
        get => (VerticalAlignment)GetValue(KeyVerticalContentAlignmentProperty);
        set => SetValue(KeyVerticalContentAlignmentProperty, value);
    }

    #endregion

    #region ccKeyTextBlock

    public static readonly DependencyProperty KeyLineHeightProperty = DependencyProperty.Register(nameof(KeyLineHeight), typeof(double), typeof(TextField), new PropertyMetadata(TextBlock.LineHeightProperty.DefaultMetadata.DefaultValue));
    public double KeyLineHeight
    {
        get => (double)GetValue(KeyLineHeightProperty);
        set => SetValue(KeyLineHeightProperty, value);
    }

    public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(nameof(Key), typeof(string), typeof(TextField), new PropertyMetadata(TextBlock.TextProperty.DefaultMetadata.DefaultValue));
    public string? Key
    {
        get => (string?)GetValue(KeyProperty);
        set => SetValue(KeyProperty, value);
    }

    public static readonly DependencyProperty KeyTextAlignmentProperty = DependencyProperty.Register(nameof(KeyTextAlignment), typeof(TextAlignment), typeof(TextField), new PropertyMetadata(TextBlock.TextAlignmentProperty.DefaultMetadata.DefaultValue));
    public TextAlignment KeyTextAlignment
    {
        get => (TextAlignment)GetValue(KeyTextAlignmentProperty);
        set => SetValue(KeyTextAlignmentProperty, value);
    }

    public static readonly DependencyProperty KeyTextTrimmingProperty = DependencyProperty.Register(nameof(KeyTextTrimming), typeof(TextTrimming), typeof(TextField), new PropertyMetadata(TextBlock.TextTrimmingProperty.DefaultMetadata.DefaultValue));
    public TextTrimming KeyTextTrimming
    {
        get => (TextTrimming)GetValue(KeyTextTrimmingProperty);
        set => SetValue(KeyTextTrimmingProperty, value);
    }

    public static readonly DependencyProperty KeyTextWrappingProperty = DependencyProperty.Register(nameof(KeyTextWrapping), typeof(TextWrapping), typeof(TextField), new PropertyMetadata(TextBlock.TextWrappingProperty.DefaultMetadata.DefaultValue));
    public TextWrapping KeyTextWrapping
    {
        get => (TextWrapping)GetValue(KeyTextWrappingProperty);
        set => SetValue(KeyTextWrappingProperty, value);
    }

    #endregion

    #region ccValueBorder

    public static readonly DependencyProperty ValueBackgroundProperty = DependencyProperty.Register(nameof(ValueBackground), typeof(Brush), typeof(TextField), new PropertyMetadata(BackgroundProperty.DefaultMetadata.DefaultValue));
    public Brush? ValueBackground
    {
        get => (Brush?)GetValue(ValueBackgroundProperty);
        set => SetValue(ValueBackgroundProperty, value);
    }

    public static readonly DependencyProperty ValueBorderBrushProperty = DependencyProperty.Register(nameof(ValueBorderBrush), typeof(Brush), typeof(TextField), new PropertyMetadata(BorderBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? ValueBorderBrush
    {
        get => (Brush?)GetValue(ValueBorderBrushProperty);
        set => SetValue(ValueBorderBrushProperty, value);
    }

    public static readonly DependencyProperty ValueBorderThicknessProperty = DependencyProperty.Register(nameof(ValueBorderThickness), typeof(Thickness), typeof(TextField), new PropertyMetadata(BorderThicknessProperty.DefaultMetadata.DefaultValue));
    public Thickness ValueBorderThickness
    {
        get => (Thickness)GetValue(ValueBorderThicknessProperty);
        set => SetValue(ValueBorderThicknessProperty, value);
    }

    public static readonly DependencyProperty ValueCornerRadiusProperty = DependencyProperty.Register(nameof(ValueCornerRadius), typeof(CornerRadius), typeof(TextField), new PropertyMetadata(Border.CornerRadiusProperty.DefaultMetadata.DefaultValue));
    public CornerRadius ValueCornerRadius
    {
        get => (CornerRadius)GetValue(ValueCornerRadiusProperty);
        set => SetValue(ValueCornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ValueOpacityProperty = DependencyProperty.Register(nameof(ValueOpacity), typeof(double), typeof(TextField), new PropertyMetadata(OpacityProperty.DefaultMetadata.DefaultValue));
    public double ValueOpacity
    {
        get => (double)GetValue(ValueOpacityProperty);
        set => SetValue(ValueOpacityProperty, value);
    }

    public static readonly DependencyProperty ValuePaddingProperty = DependencyProperty.Register(nameof(ValuePadding), typeof(Thickness), typeof(TextField), new PropertyMetadata(PaddingProperty.DefaultMetadata.DefaultValue));
    public Thickness ValuePadding
    {
        get => (Thickness)GetValue(ValuePaddingProperty);
        set => SetValue(ValuePaddingProperty, value);
    }

    public static readonly DependencyProperty ValueVisiblityProperty = DependencyProperty.Register(nameof(ValueVisiblity), typeof(Visibility), typeof(TextField), new PropertyMetadata(VisibilityProperty.DefaultMetadata.DefaultValue));
    public Visibility ValueVisiblity
    {
        get => (Visibility)GetValue(ValueVisiblityProperty);
        set => SetValue(ValueVisiblityProperty, value);
    }

    public static readonly DependencyProperty ValueWidthProperty = DependencyProperty.Register(nameof(ValueWidth), typeof(double), typeof(TextField), new PropertyMetadata(double.NaN));
    public double ValueWidth
    {
        get => (double)GetValue(ValueWidthProperty);
        set => SetValue(ValueWidthProperty, value);
    }

    public static readonly DependencyProperty ValueMinWidthProperty = DependencyProperty.Register(nameof(ValueMinWidth), typeof(double), typeof(TextField), new PropertyMetadata(MinWidthProperty.DefaultMetadata.DefaultValue));
    public double ValueMinWidth
    {
        get => (double)GetValue(ValueMinWidthProperty);
        set => SetValue(ValueMinWidthProperty, value);
    }

    public static readonly DependencyProperty ValueMaxWidthProperty = DependencyProperty.Register(nameof(ValueMaxWidth), typeof(double), typeof(TextField), new PropertyMetadata(MaxWidthProperty.DefaultMetadata.DefaultValue));
    public double ValueMaxWidth
    {
        get => (double)GetValue(ValueMaxWidthProperty);
        set => SetValue(ValueMaxWidthProperty, value);
    }

    #endregion

    #region ccValueTextBox

    public static readonly DependencyProperty CaretBrushProperty = DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(TextField), new PropertyMetadata(TextBoxBase.CaretBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? CaretBrush
    {
        get => (Brush?)GetValue(CaretBrushProperty);
        set => SetValue(CaretBrushProperty, value);
    }

    public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.Register(nameof(CharacterCasing), typeof(CharacterCasing), typeof(TextField), new PropertyMetadata(TextBox.CharacterCasingProperty.DefaultMetadata.DefaultValue));
    public CharacterCasing CharacterCasing
    {
        get => (CharacterCasing)GetValue(CharacterCasingProperty);
        set => SetValue(CharacterCasingProperty, value);
    }

    public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = DependencyProperty.Register(nameof(HorizontalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(TextField), new PropertyMetadata(ScrollBarVisibility.Hidden));
    public ScrollBarVisibility HorizontalScrollBarVisibility
    {
        get => (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty);
        set => SetValue(HorizontalScrollBarVisibilityProperty, value);
    }

    public static readonly DependencyProperty IsInactiveSelectionHighlightEnabledProperty = DependencyProperty.Register(nameof(IsInactiveSelectionHighlightEnabled), typeof(bool), typeof(TextField), new PropertyMetadata(TextBoxBase.IsInactiveSelectionHighlightEnabledProperty.DefaultMetadata.DefaultValue));
    public bool IsInactiveSelectionHighlightEnabled
    {
        get => (bool)GetValue(IsInactiveSelectionHighlightEnabledProperty);
        set => SetValue(IsInactiveSelectionHighlightEnabledProperty, value);
    }

    public static readonly DependencyProperty IsReadOnlyCaretVisibleProperty = DependencyProperty.Register(nameof(IsReadOnlyCaretVisible), typeof(bool), typeof(TextField), new PropertyMetadata(TextBoxBase.IsReadOnlyCaretVisibleProperty.DefaultMetadata.DefaultValue));
    public bool IsReadOnlyCaretVisible
    {
        get => (bool)GetValue(IsReadOnlyCaretVisibleProperty);
        set => SetValue(IsReadOnlyCaretVisibleProperty, value);
    }

    public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(nameof(MaxLength), typeof(int), typeof(TextField), new PropertyMetadata(TextBox.MaxLengthProperty.DefaultMetadata.DefaultValue));
    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    public static readonly DependencyProperty MaxLinesProperty = DependencyProperty.Register(nameof(MaxLines), typeof(int), typeof(TextField), new PropertyMetadata(TextBox.MaxLinesProperty.DefaultMetadata.DefaultValue));
    public int MaxLines
    {
        get => (int)GetValue(MaxLinesProperty);
        set => SetValue(MaxLinesProperty, value);
    }

    public static readonly DependencyProperty MinLinesProperty = DependencyProperty.Register(nameof(MinLines), typeof(int), typeof(TextField), new PropertyMetadata(TextBox.MinLinesProperty.DefaultMetadata.DefaultValue));
    public int MinLines
    {
        get => (int)GetValue(MinLinesProperty);
        set => SetValue(MinLinesProperty, value);
    }

    public static readonly DependencyProperty SelectionBrushProperty = DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(TextField), new PropertyMetadata(TextBoxBase.SelectionBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? SelectionBrush
    {
        get => (Brush?)GetValue(SelectionBrushProperty);
        set => SetValue(SelectionBrushProperty, value);
    }

    public static readonly DependencyProperty SelectionOpacityProperty = DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(TextField), new PropertyMetadata(TextBoxBase.SelectionOpacityProperty.DefaultMetadata.DefaultValue));
    public double SelectionOpacity
    {
        get => (double)GetValue(SelectionOpacityProperty);
        set => SetValue(SelectionOpacityProperty, value);
    }

    public static readonly DependencyProperty SelectionTextBrushProperty = DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(TextField), new PropertyMetadata(TextBoxBase.SelectionTextBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? SelectionTextBrush
    {
        get => (Brush?)GetValue(SelectionTextBrushProperty);
        set => SetValue(SelectionTextBrushProperty, value);
    }

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(string), typeof(TextField), new PropertyMetadata(TextBox.TextProperty.DefaultMetadata.DefaultValue));
    public string? Value
    {
        get => (string?)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(TextField), new PropertyMetadata(TextBox.TextAlignmentProperty.DefaultMetadata.DefaultValue));
    public TextAlignment TextAlignment
    {
        get => (TextAlignment)GetValue(TextAlignmentProperty);
        set => SetValue(TextAlignmentProperty, value);
    }

    public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(nameof(TextWrapping), typeof(TextWrapping), typeof(TextField), new PropertyMetadata(TextBox.TextWrappingProperty.DefaultMetadata.DefaultValue));
    public TextWrapping TextWrapping
    {
        get => (TextWrapping)GetValue(TextWrappingProperty);
        set => SetValue(TextWrappingProperty, value);
    }

    public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = DependencyProperty.Register(nameof(VerticalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(TextField), new PropertyMetadata(ScrollBarVisibility.Hidden));
    public ScrollBarVisibility VerticalScrollBarVisibility
    {
        get => (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty);
        set => SetValue(VerticalScrollBarVisibilityProperty, value);
    }

    public static readonly DependencyProperty InputBindingsProperty = DependencyProperty.RegisterAttached(nameof(InputBindings), typeof(InputBindingCollection), typeof(TextField), new FrameworkPropertyMetadata(new InputBindingCollection(), OnInputBindings_PropertyChanged));
    public new InputBindingCollection? InputBindings
    {
        get => (InputBindingCollection?)GetValue(InputBindingsProperty);
        set => SetValue(InputBindingsProperty, value);
    }
    private static void OnInputBindings_PropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
    {
        if (sender is not null and TextField textField)
        {
            textField.SetInputTextBoxBinding((InputBindingCollection?)args.NewValue);
        }
    }

    #endregion

    private void SetInputTextBoxBinding(InputBindingCollection? inputBindingCollection)
    {
        PreBindInputBindingCollection = inputBindingCollection;
        if (ValueTextBox is not null && PreBindInputBindingCollection is not null)
        {
            ValueTextBox.InputBindings?.Clear();
            ValueTextBox.InputBindings?.AddRange(PreBindInputBindingCollection);
        }
    }
}
