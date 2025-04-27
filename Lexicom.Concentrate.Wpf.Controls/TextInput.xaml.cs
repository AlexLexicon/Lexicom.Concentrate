using Lexicom.Validation;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Lexicom.Concentrate.Wpf.Controls;
public partial class TextInput : UserControl
{
    public TextInput()
    {
        InitializeComponent();

        //if I use the default metadata it shares the
        //same collection with all TextInput instances
        Errors = [];
    }

    private InputBindingCollection? PreBindInputBindingCollection { get; set; }

    private TextBox? _inputTextBox;
    private TextBox? InputTextBox
    {
        get => _inputTextBox;
        set
        {
            _inputTextBox = value;
            SetInputTextBoxBinding(PreBindInputBindingCollection);
        }
    }

    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(TextInput), new PropertyMetadata(System.Windows.Controls.Orientation.Vertical));
    public Orientation? Orientation
    {
        get => (Orientation?)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public static readonly DependencyProperty ErrorsOrientationProperty = DependencyProperty.Register(nameof(ErrorsOrientation), typeof(Orientation), typeof(TextInput), new PropertyMetadata(System.Windows.Controls.Orientation.Vertical));
    public Orientation? ErrorsOrientation
    {
        get => (Orientation?)GetValue(ErrorsOrientationProperty);
        set => SetValue(ErrorsOrientationProperty, value);
    }

    #region lccTitleBorder

    public static readonly DependencyProperty TitleBackgroundProperty = DependencyProperty.Register(nameof(TitleBackground), typeof(Brush), typeof(TextInput), new PropertyMetadata(BackgroundProperty.DefaultMetadata.DefaultValue));
    public Brush? TitleBackground
    {
        get => (Brush?)GetValue(TitleBackgroundProperty);
        set => SetValue(TitleBackgroundProperty, value);
    }

    public static readonly DependencyProperty TitleBorderBrushProperty = DependencyProperty.Register(nameof(TitleBorderBrush), typeof(Brush), typeof(TextInput), new PropertyMetadata(BorderBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? TitleBorderBrush
    {
        get => (Brush?)GetValue(TitleBorderBrushProperty);
        set => SetValue(TitleBorderBrushProperty, value);
    }

    public static readonly DependencyProperty TitleBorderThicknessProperty = DependencyProperty.Register(nameof(TitleBorderThickness), typeof(Thickness), typeof(TextInput), new PropertyMetadata(BorderThicknessProperty.DefaultMetadata.DefaultValue));
    public Thickness TitleBorderThickness
    {
        get => (Thickness)GetValue(TitleBorderThicknessProperty);
        set => SetValue(TitleBorderThicknessProperty, value);
    }

    public static readonly DependencyProperty TitleCornerRadiusProperty = DependencyProperty.Register(nameof(TitleCornerRadius), typeof(CornerRadius), typeof(TextInput), new PropertyMetadata(Border.CornerRadiusProperty.DefaultMetadata.DefaultValue));
    public CornerRadius TitleCornerRadius
    {
        get => (CornerRadius)GetValue(TitleCornerRadiusProperty);
        set => SetValue(TitleCornerRadiusProperty, value);
    }

    public static readonly DependencyProperty TitleHeightProperty = DependencyProperty.Register(nameof(TitleHeight), typeof(double), typeof(TextInput), new PropertyMetadata(double.NaN));
    public double TitleHeight
    {
        get => (double)GetValue(TitleHeightProperty);
        set => SetValue(TitleHeightProperty, value);
    }

    public static readonly DependencyProperty TitleMinHeightProperty = DependencyProperty.Register(nameof(TitleMinHeight), typeof(double), typeof(TextInput), new PropertyMetadata(MinHeightProperty.DefaultMetadata.DefaultValue));
    public double TitleMinHeight
    {
        get => (double)GetValue(TitleMinHeightProperty);
        set => SetValue(TitleMinHeightProperty, value);
    }

    public static readonly DependencyProperty TitleMaxHeightProperty = DependencyProperty.Register(nameof(TitleMaxHeight), typeof(double), typeof(TextInput), new PropertyMetadata(MaxHeightProperty.DefaultMetadata.DefaultValue));
    public double TitleMaxHeight
    {
        get => (double)GetValue(TitleMaxHeightProperty);
        set => SetValue(TitleMaxHeightProperty, value);
    }

    public static readonly DependencyProperty TitleOpacityProperty = DependencyProperty.Register(nameof(TitleOpacity), typeof(double), typeof(TextInput), new PropertyMetadata(OpacityProperty.DefaultMetadata.DefaultValue));
    public double TitleOpacity
    {
        get => (double)GetValue(TitleOpacityProperty);
        set => SetValue(TitleOpacityProperty, value);
    }

    public static readonly DependencyProperty TitlePaddingProperty = DependencyProperty.Register(nameof(TitlePadding), typeof(Thickness), typeof(TextInput), new PropertyMetadata(PaddingProperty.DefaultMetadata.DefaultValue));
    public Thickness TitlePadding
    {
        get => (Thickness)GetValue(TitlePaddingProperty);
        set => SetValue(TitlePaddingProperty, value);
    }

    public static readonly DependencyProperty TitleVisiblityProperty = DependencyProperty.Register(nameof(TitleVisiblity), typeof(Visibility), typeof(TextInput), new PropertyMetadata(VisibilityProperty.DefaultMetadata.DefaultValue));
    public Visibility TitleVisiblity
    {
        get => (Visibility)GetValue(TitleVisiblityProperty);
        set => SetValue(TitleVisiblityProperty, value);
    }

    public static readonly DependencyProperty TitleWidthProperty = DependencyProperty.Register(nameof(TitleWidth), typeof(double), typeof(TextInput), new PropertyMetadata(double.NaN));
    public double TitleWidth
    {
        get => (double)GetValue(TitleWidthProperty);
        set => SetValue(TitleWidthProperty, value);
    }

    public static readonly DependencyProperty TitleMinWidthProperty = DependencyProperty.Register(nameof(TitleMinWidth), typeof(double), typeof(TextInput), new PropertyMetadata(MinWidthProperty.DefaultMetadata.DefaultValue));
    public double TitleMinWidth
    {
        get => (double)GetValue(TitleMinWidthProperty);
        set => SetValue(TitleMinWidthProperty, value);
    }

    public static readonly DependencyProperty TitleMaxWidthProperty = DependencyProperty.Register(nameof(TitleMaxWidth), typeof(double), typeof(TextInput), new PropertyMetadata(MaxWidthProperty.DefaultMetadata.DefaultValue));
    public double TitleMaxWidth
    {
        get => (double)GetValue(TitleMaxWidthProperty);
        set => SetValue(TitleMaxWidthProperty, value);
    }

    #endregion

    #region lccTitleLabel

    public static readonly DependencyProperty TitleFlowDirectionProperty = DependencyProperty.Register(nameof(TitleFlowDirection), typeof(FlowDirection), typeof(TextInput), new PropertyMetadata(FlowDirectionProperty.DefaultMetadata.DefaultValue));
    public FlowDirection TitleFlowDirection
    {
        get => (FlowDirection)GetValue(TitleFlowDirectionProperty);
        set => SetValue(TitleFlowDirectionProperty, value);
    }

    public static readonly DependencyProperty TitleFontFamilyProperty = DependencyProperty.Register(nameof(TitleFontFamily), typeof(FontFamily), typeof(TextInput), new PropertyMetadata(FontFamilyProperty.DefaultMetadata.DefaultValue));
    public FontFamily? TitleFontFamily
    {
        get => (FontFamily?)GetValue(TitleFontFamilyProperty);
        set => SetValue(TitleFontFamilyProperty, value);
    }

    public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register(nameof(TitleFontSize), typeof(double), typeof(TextInput), new PropertyMetadata(FontSizeProperty.DefaultMetadata.DefaultValue));
    public double TitleFontSize
    {
        get => (double)GetValue(TitleFontSizeProperty);
        set => SetValue(TitleFontSizeProperty, value);
    }

    public static readonly DependencyProperty TitleFontStretchProperty = DependencyProperty.Register(nameof(TitleFontStretch), typeof(FontStretch), typeof(TextInput), new PropertyMetadata(FontStretchProperty.DefaultMetadata.DefaultValue));
    public FontStretch TitleFontStretch
    {
        get => (FontStretch)GetValue(TitleFontStretchProperty);
        set => SetValue(TitleFontStretchProperty, value);
    }

    public static readonly DependencyProperty TitleFontStyleProperty = DependencyProperty.Register(nameof(TitleFontStyle), typeof(FontStyle), typeof(TextInput), new PropertyMetadata(FontStyleProperty.DefaultMetadata.DefaultValue));
    public FontStyle TitleFontStyle
    {
        get => (FontStyle)GetValue(TitleFontStyleProperty);
        set => SetValue(TitleFontStyleProperty, value);
    }

    public static readonly DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(nameof(TitleFontWeight), typeof(FontWeight), typeof(TextInput), new PropertyMetadata(FontWeightProperty.DefaultMetadata.DefaultValue));
    public FontWeight TitleFontWeight
    {
        get => (FontWeight)GetValue(TitleFontWeightProperty);
        set => SetValue(TitleFontWeightProperty, value);
    }

    public static readonly DependencyProperty TitleForegroundProperty = DependencyProperty.Register(nameof(TitleForeground), typeof(Brush), typeof(TextInput), new PropertyMetadata(ForegroundProperty.DefaultMetadata.DefaultValue));
    public Brush? TitleForeground
    {
        get => (Brush?)GetValue(TitleForegroundProperty);
        set => SetValue(TitleForegroundProperty, value);
    }

    public static readonly DependencyProperty TitleHorizontalContentAlignmentProperty = DependencyProperty.Register(nameof(TitleHorizontalContentAlignment), typeof(HorizontalAlignment), typeof(TextInput), new PropertyMetadata(HorizontalContentAlignmentProperty.DefaultMetadata.DefaultValue));
    public HorizontalAlignment TitleHorizontalContentAlignment
    {
        get => (HorizontalAlignment)GetValue(TitleHorizontalContentAlignmentProperty);
        set => SetValue(TitleHorizontalContentAlignmentProperty, value);
    }

    public static readonly DependencyProperty TitleVerticalContentAlignmentProperty = DependencyProperty.Register(nameof(TitleVerticalContentAlignment), typeof(VerticalAlignment), typeof(TextInput), new PropertyMetadata(VerticalAlignment.Center));
    public VerticalAlignment TitleVerticalContentAlignment
    {
        get => (VerticalAlignment)GetValue(TitleVerticalContentAlignmentProperty);
        set => SetValue(TitleVerticalContentAlignmentProperty, value);
    }

    #endregion

    #region lccTitleTextBlock

    public static readonly DependencyProperty TitleLineHeightProperty = DependencyProperty.Register(nameof(TitleLineHeight), typeof(double), typeof(TextInput), new PropertyMetadata(TextBlock.LineHeightProperty.DefaultMetadata.DefaultValue));
    public double TitleLineHeight
    {
        get => (double)GetValue(TitleLineHeightProperty);
        set => SetValue(TitleLineHeightProperty, value);
    }

    public static readonly DependencyProperty TitleTextProperty = DependencyProperty.Register(nameof(TitleText), typeof(string), typeof(TextInput), new PropertyMetadata(TextBlock.TextProperty.DefaultMetadata.DefaultValue));
    public string? TitleText
    {
        get => (string?)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    public static readonly DependencyProperty TitleTextAlignmentProperty = DependencyProperty.Register(nameof(TitleTextAlignment), typeof(TextAlignment), typeof(TextInput), new PropertyMetadata(TextBlock.TextAlignmentProperty.DefaultMetadata.DefaultValue));
    public TextAlignment TitleTextAlignment
    {
        get => (TextAlignment)GetValue(TitleTextAlignmentProperty);
        set => SetValue(TitleTextAlignmentProperty, value);
    }

    public static readonly DependencyProperty TitleTextTrimmingProperty = DependencyProperty.Register(nameof(TitleTextTrimming), typeof(TextTrimming), typeof(TextInput), new PropertyMetadata(TextBlock.TextTrimmingProperty.DefaultMetadata.DefaultValue));
    public TextTrimming TitleTextTrimming
    {
        get => (TextTrimming)GetValue(TitleTextTrimmingProperty);
        set => SetValue(TitleTextTrimmingProperty, value);
    }

    public static readonly DependencyProperty TitleTextWrappingProperty = DependencyProperty.Register(nameof(TitleTextWrapping), typeof(TextWrapping), typeof(TextInput), new PropertyMetadata(TextBlock.TextWrappingProperty.DefaultMetadata.DefaultValue));
    public TextWrapping TitleTextWrapping
    {
        get => (TextWrapping)GetValue(TitleTextWrappingProperty);
        set => SetValue(TitleTextWrappingProperty, value);
    }

    #endregion

    #region lccInputBorder

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(TextInput), new PropertyMetadata(Border.CornerRadiusProperty.DefaultMetadata.DefaultValue));
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty InputHeightProperty = DependencyProperty.Register(nameof(InputHeight), typeof(double), typeof(TextInput), new PropertyMetadata(double.NaN));
    public double InputHeight
    {
        get => (double)GetValue(InputHeightProperty);
        set => SetValue(InputHeightProperty, value);
    }

    public static readonly DependencyProperty InputMinHeightProperty = DependencyProperty.Register(nameof(InputMinHeight), typeof(double), typeof(TextInput), new PropertyMetadata(MinHeightProperty.DefaultMetadata.DefaultValue));
    public double InputMinHeight
    {
        get => (double)GetValue(InputMinHeightProperty);
        set => SetValue(InputMinHeightProperty, value);
    }

    public static readonly DependencyProperty InputMaxHeightProperty = DependencyProperty.Register(nameof(InputMaxHeight), typeof(double), typeof(TextInput), new PropertyMetadata(MaxHeightProperty.DefaultMetadata.DefaultValue));
    public double InputMaxHeight
    {
        get => (double)GetValue(InputMaxHeightProperty);
        set => SetValue(InputMaxHeightProperty, value);
    }

    public static readonly DependencyProperty InputOpacityProperty = DependencyProperty.Register(nameof(InputOpacity), typeof(double), typeof(TextInput), new PropertyMetadata(OpacityProperty.DefaultMetadata.DefaultValue));
    public double InputOpacity
    {
        get => (double)GetValue(InputOpacityProperty);
        set => SetValue(InputOpacityProperty, value);
    }

    public static readonly DependencyProperty InputVisiblityProperty = DependencyProperty.Register(nameof(InputVisiblity), typeof(Visibility), typeof(TextInput), new PropertyMetadata(VisibilityProperty.DefaultMetadata.DefaultValue));
    public Visibility InputVisiblity
    {
        get => (Visibility)GetValue(InputVisiblityProperty);
        set => SetValue(InputVisiblityProperty, value);
    }

    public static readonly DependencyProperty InputWidthProperty = DependencyProperty.Register(nameof(InputWidth), typeof(double), typeof(TextInput), new PropertyMetadata(defaultValue: double.NaN));
    public double InputWidth
    {
        get => (double)GetValue(InputWidthProperty);
        set => SetValue(InputWidthProperty, value);
    }

    public static readonly DependencyProperty InputMinWidthProperty = DependencyProperty.Register(nameof(InputMinWidth), typeof(double), typeof(TextInput), new PropertyMetadata(MinWidthProperty.DefaultMetadata.DefaultValue));
    public double InputMinWidth
    {
        get => (double)GetValue(InputMinWidthProperty);
        set => SetValue(InputMinWidthProperty, value);
    }

    public static readonly DependencyProperty InputMaxWidthProperty = DependencyProperty.Register(nameof(InputMaxWidth), typeof(double), typeof(TextInput), new PropertyMetadata(MaxWidthProperty.DefaultMetadata.DefaultValue));
    public double InputMaxWidth
    {
        get => (double)GetValue(InputMaxWidthProperty);
        set => SetValue(InputMaxWidthProperty, value);
    }

    #endregion

    #region lccInputTextBox

    public static readonly DependencyProperty AcceptsReturnProperty = DependencyProperty.Register(nameof(AcceptsReturn), typeof(bool), typeof(TextInput), new PropertyMetadata(TextBoxBase.AcceptsReturnProperty.DefaultMetadata.DefaultValue));
    public bool AcceptsReturn
    {
        get => (bool)GetValue(AcceptsReturnProperty);
        set => SetValue(AcceptsReturnProperty, value);
    }

    public static readonly DependencyProperty AcceptsTabProperty = DependencyProperty.Register(nameof(AcceptsTab), typeof(bool), typeof(TextInput), new PropertyMetadata(TextBoxBase.AcceptsTabProperty.DefaultMetadata.DefaultValue));
    public bool AcceptsTab
    {
        get => (bool)GetValue(AcceptsTabProperty);
        set => SetValue(AcceptsTabProperty, value);
    }

    public static readonly DependencyProperty CaretBrushProperty = DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(TextInput), new PropertyMetadata(TextBoxBase.CaretBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? CaretBrush
    {
        get => (Brush?)GetValue(CaretBrushProperty);
        set => SetValue(CaretBrushProperty, value);
    }

    public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.Register(nameof(CharacterCasing), typeof(CharacterCasing), typeof(TextInput), new PropertyMetadata(TextBox.CharacterCasingProperty.DefaultMetadata.DefaultValue));
    public CharacterCasing CharacterCasing
    {
        get => (CharacterCasing)GetValue(CharacterCasingProperty);
        set => SetValue(CharacterCasingProperty, value);
    }

    public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = DependencyProperty.Register(nameof(HorizontalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(TextInput), new PropertyMetadata(ScrollBarVisibility.Hidden));
    public ScrollBarVisibility HorizontalScrollBarVisibility
    {
        get => (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty);
        set => SetValue(HorizontalScrollBarVisibilityProperty, value);
    }

    public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(TextInput), new PropertyMetadata(TextBoxBase.IsReadOnlyProperty.DefaultMetadata.DefaultValue));
    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    public static readonly DependencyProperty IsInactiveSelectionHighlightEnabledProperty = DependencyProperty.Register(nameof(IsInactiveSelectionHighlightEnabled), typeof(bool), typeof(TextInput), new PropertyMetadata(TextBoxBase.IsInactiveSelectionHighlightEnabledProperty.DefaultMetadata.DefaultValue));
    public bool IsInactiveSelectionHighlightEnabled
    {
        get => (bool)GetValue(IsInactiveSelectionHighlightEnabledProperty);
        set => SetValue(IsInactiveSelectionHighlightEnabledProperty, value);
    }

    public static readonly DependencyProperty IsReadOnlyCaretVisibleProperty = DependencyProperty.Register(nameof(IsReadOnlyCaretVisible), typeof(bool), typeof(TextInput), new PropertyMetadata(TextBoxBase.IsReadOnlyCaretVisibleProperty.DefaultMetadata.DefaultValue));
    public bool IsReadOnlyCaretVisible
    {
        get => (bool)GetValue(IsReadOnlyCaretVisibleProperty);
        set => SetValue(IsReadOnlyCaretVisibleProperty, value);
    }

    public static readonly DependencyProperty IsUndoEnabledProperty = DependencyProperty.Register(nameof(IsUndoEnabled), typeof(bool), typeof(TextInput), new PropertyMetadata(TextBoxBase.IsUndoEnabledProperty.DefaultMetadata.DefaultValue));
    public bool IsUndoEnabled
    {
        get => (bool)GetValue(IsUndoEnabledProperty);
        set => SetValue(IsUndoEnabledProperty, value);
    }

    public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(nameof(MaxLength), typeof(int), typeof(TextInput), new PropertyMetadata(TextBox.MaxLengthProperty.DefaultMetadata.DefaultValue));
    public int MaxLength
    {
        get => (int)GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    public static readonly DependencyProperty MaxLinesProperty = DependencyProperty.Register(nameof(MaxLines), typeof(int), typeof(TextInput), new PropertyMetadata(TextBox.MaxLinesProperty.DefaultMetadata.DefaultValue));
    public int MaxLines
    {
        get => (int)GetValue(MaxLinesProperty);
        set => SetValue(MaxLinesProperty, value);
    }

    public static readonly DependencyProperty MinLinesProperty = DependencyProperty.Register(nameof(MinLines), typeof(int), typeof(TextInput), new PropertyMetadata(TextBox.MinLinesProperty.DefaultMetadata.DefaultValue));
    public int MinLines
    {
        get => (int)GetValue(MinLinesProperty);
        set => SetValue(MinLinesProperty, value);
    }

    public static readonly DependencyProperty SelectionBrushProperty = DependencyProperty.Register(nameof(SelectionBrush), typeof(Brush), typeof(TextInput), new PropertyMetadata(TextBoxBase.SelectionBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? SelectionBrush
    {
        get => (Brush?)GetValue(SelectionBrushProperty);
        set => SetValue(SelectionBrushProperty, value);
    }

    public static readonly DependencyProperty SelectionOpacityProperty = DependencyProperty.Register(nameof(SelectionOpacity), typeof(double), typeof(TextInput), new PropertyMetadata(TextBoxBase.SelectionOpacityProperty.DefaultMetadata.DefaultValue));
    public double SelectionOpacity
    {
        get => (double)GetValue(SelectionOpacityProperty);
        set => SetValue(SelectionOpacityProperty, value);
    }

    public static readonly DependencyProperty SelectionTextBrushProperty = DependencyProperty.Register(nameof(SelectionTextBrush), typeof(Brush), typeof(TextInput), new PropertyMetadata(TextBoxBase.SelectionTextBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? SelectionTextBrush
    {
        get => (Brush?)GetValue(SelectionTextBrushProperty);
        set => SetValue(SelectionTextBrushProperty, value);
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextInput), new PropertyMetadata(TextBox.TextProperty.DefaultMetadata.DefaultValue));
    public string? Text
    {
        get => (string?)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register(nameof(TextAlignment), typeof(TextAlignment), typeof(TextInput), new PropertyMetadata(TextBox.TextAlignmentProperty.DefaultMetadata.DefaultValue));
    public TextAlignment TextAlignment
    {
        get => (TextAlignment)GetValue(TextAlignmentProperty);
        set => SetValue(TextAlignmentProperty, value);
    }

    public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(nameof(TextWrapping), typeof(TextWrapping), typeof(TextInput), new PropertyMetadata(TextBox.TextWrappingProperty.DefaultMetadata.DefaultValue));
    public TextWrapping TextWrapping
    {
        get => (TextWrapping)GetValue(TextWrappingProperty);
        set => SetValue(TextWrappingProperty, value);
    }

    public static readonly DependencyProperty UndoLimitProperty = DependencyProperty.Register(nameof(UndoLimit), typeof(int), typeof(TextInput), new PropertyMetadata(TextBoxBase.UndoLimitProperty.DefaultMetadata.DefaultValue));
    public int UndoLimit
    {
        get => (int)GetValue(UndoLimitProperty);
        set => SetValue(UndoLimitProperty, value);
    }

    public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = DependencyProperty.Register(nameof(VerticalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(TextInput), new PropertyMetadata(ScrollBarVisibility.Hidden));
    public ScrollBarVisibility VerticalScrollBarVisibility
    {
        get => (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty);
        set => SetValue(VerticalScrollBarVisibilityProperty, value);
    }

    public static readonly DependencyProperty InputBindingsProperty = DependencyProperty.RegisterAttached(nameof(InputBindings), typeof(InputBindingCollection), typeof(TextInput), new FrameworkPropertyMetadata(new InputBindingCollection(), OnInputBindings_PropertyChanged));
    public new InputBindingCollection? InputBindings
    {
        get => (InputBindingCollection?)GetValue(InputBindingsProperty);
        set => SetValue(InputBindingsProperty, value);
    }
    private static void OnInputBindings_PropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
    {
        if (sender is not null and TextInput textInput)
        {
            textInput.SetInputTextBoxBinding((InputBindingCollection?)args.NewValue);
        }
    }

    #endregion

    #region lccErrorBorder

    public static readonly DependencyProperty ErrorBackgroundProperty = DependencyProperty.Register(nameof(ErrorBackground), typeof(Brush), typeof(TextInput), new PropertyMetadata(BackgroundProperty.DefaultMetadata.DefaultValue));
    public Brush? ErrorBackground
    {
        get => (Brush?)GetValue(ErrorBackgroundProperty);
        set => SetValue(ErrorBackgroundProperty, value);
    }

    public static readonly DependencyProperty ErrorBorderBrushProperty = DependencyProperty.Register(nameof(ErrorBorderBrush), typeof(Brush), typeof(TextInput), new PropertyMetadata(BorderBrushProperty.DefaultMetadata.DefaultValue));
    public Brush? ErrorBorderBrush
    {
        get => (Brush?)GetValue(ErrorBorderBrushProperty);
        set => SetValue(ErrorBorderBrushProperty, value);
    }

    public static readonly DependencyProperty ErrorBorderThicknessProperty = DependencyProperty.Register(nameof(ErrorBorderThickness), typeof(Thickness), typeof(TextInput), new PropertyMetadata(BorderThicknessProperty.DefaultMetadata.DefaultValue));
    public Thickness ErrorBorderThickness
    {
        get => (Thickness)GetValue(ErrorBorderThicknessProperty);
        set => SetValue(ErrorBorderThicknessProperty, value);
    }

    public static readonly DependencyProperty ErrorCornerRadiusProperty = DependencyProperty.Register(nameof(ErrorCornerRadius), typeof(CornerRadius), typeof(TextInput), new PropertyMetadata(Border.CornerRadiusProperty.DefaultMetadata.DefaultValue));
    public CornerRadius ErrorCornerRadius
    {
        get => (CornerRadius)GetValue(ErrorCornerRadiusProperty);
        set => SetValue(ErrorCornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ErrorHeightProperty = DependencyProperty.Register(nameof(ErrorHeight), typeof(double), typeof(TextInput), new PropertyMetadata(double.NaN));
    public double ErrorHeight
    {
        get => (double)GetValue(ErrorHeightProperty);
        set => SetValue(ErrorHeightProperty, value);
    }

    public static readonly DependencyProperty ErrorMinHeightProperty = DependencyProperty.Register(nameof(ErrorMinHeight), typeof(double), typeof(TextInput), new PropertyMetadata(MinHeightProperty.DefaultMetadata.DefaultValue));
    public double ErrorMinHeight
    {
        get => (double)GetValue(ErrorMinHeightProperty);
        set => SetValue(ErrorMinHeightProperty, value);
    }

    public static readonly DependencyProperty ErrorMaxHeightProperty = DependencyProperty.Register(nameof(ErrorMaxHeight), typeof(double), typeof(TextInput), new PropertyMetadata(MaxHeightProperty.DefaultMetadata.DefaultValue));
    public double ErrorMaxHeight
    {
        get => (double)GetValue(ErrorMaxHeightProperty);
        set => SetValue(ErrorMaxHeightProperty, value);
    }

    public static readonly DependencyProperty ErrorOpacityProperty = DependencyProperty.Register(nameof(ErrorOpacity), typeof(double), typeof(TextInput), new PropertyMetadata(OpacityProperty.DefaultMetadata.DefaultValue));
    public double ErrorOpacity
    {
        get => (double)GetValue(ErrorOpacityProperty);
        set => SetValue(ErrorOpacityProperty, value);
    }

    public static readonly DependencyProperty ErrorPaddingProperty = DependencyProperty.Register(nameof(ErrorPadding), typeof(Thickness), typeof(TextInput), new PropertyMetadata(PaddingProperty.DefaultMetadata.DefaultValue));
    public Thickness ErrorPadding
    {
        get => (Thickness)GetValue(ErrorPaddingProperty);
        set => SetValue(ErrorPaddingProperty, value);
    }

    public static readonly DependencyProperty ErrorVisiblityProperty = DependencyProperty.Register(nameof(ErrorVisiblity), typeof(Visibility), typeof(TextInput), new PropertyMetadata(VisibilityProperty.DefaultMetadata.DefaultValue));
    public Visibility ErrorVisiblity
    {
        get => (Visibility)GetValue(ErrorVisiblityProperty);
        set => SetValue(ErrorVisiblityProperty, value);
    }

    public static readonly DependencyProperty ErrorWidthProperty = DependencyProperty.Register(nameof(ErrorWidth), typeof(double), typeof(TextInput), new PropertyMetadata(double.NaN));
    public double ErrorWidth
    {
        get => (double)GetValue(ErrorWidthProperty);
        set => SetValue(ErrorWidthProperty, value);
    }

    public static readonly DependencyProperty ErrorMinWidthProperty = DependencyProperty.Register(nameof(ErrorMinWidth), typeof(double), typeof(TextInput), new PropertyMetadata(MinWidthProperty.DefaultMetadata.DefaultValue));
    public double ErrorMinWidth
    {
        get => (double)GetValue(ErrorMinWidthProperty);
        set => SetValue(ErrorMinWidthProperty, value);
    }

    public static readonly DependencyProperty ErrorMaxWidthProperty = DependencyProperty.Register(nameof(ErrorMaxWidth), typeof(double), typeof(TextInput), new PropertyMetadata(MaxWidthProperty.DefaultMetadata.DefaultValue));
    public double ErrorMaxWidth
    {
        get => (double)GetValue(ErrorMaxWidthProperty);
        set => SetValue(ErrorMaxWidthProperty, value);
    }

    #endregion

    #region lccErrorLabel

    public static readonly DependencyProperty ErrorFlowDirectionProperty = DependencyProperty.Register(nameof(ErrorFlowDirection), typeof(FlowDirection), typeof(TextInput), new PropertyMetadata(FlowDirectionProperty.DefaultMetadata.DefaultValue));
    public FlowDirection ErrorFlowDirection
    {
        get => (FlowDirection)GetValue(ErrorFlowDirectionProperty);
        set => SetValue(ErrorFlowDirectionProperty, value);
    }

    public static readonly DependencyProperty ErrorFontFamilyProperty = DependencyProperty.Register(nameof(ErrorFontFamily), typeof(FontFamily), typeof(TextInput), new PropertyMetadata(FontFamilyProperty.DefaultMetadata.DefaultValue));
    public FontFamily? ErrorFontFamily
    {
        get => (FontFamily?)GetValue(ErrorFontFamilyProperty);
        set => SetValue(ErrorFontFamilyProperty, value);
    }

    public static readonly DependencyProperty ErrorFontSizeProperty = DependencyProperty.Register(nameof(ErrorFontSize), typeof(double), typeof(TextInput), new PropertyMetadata(FontSizeProperty.DefaultMetadata.DefaultValue));
    public double ErrorFontSize
    {
        get => (double)GetValue(ErrorFontSizeProperty);
        set => SetValue(ErrorFontSizeProperty, value);
    }

    public static readonly DependencyProperty ErrorFontStretchProperty = DependencyProperty.Register(nameof(ErrorFontStretch), typeof(FontStretch), typeof(TextInput), new PropertyMetadata(FontStretchProperty.DefaultMetadata.DefaultValue));
    public FontStretch ErrorFontStretch
    {
        get => (FontStretch)GetValue(ErrorFontStretchProperty);
        set => SetValue(ErrorFontStretchProperty, value);
    }

    public static readonly DependencyProperty ErrorFontStyleProperty = DependencyProperty.Register(nameof(ErrorFontStyle), typeof(FontStyle), typeof(TextInput), new PropertyMetadata(FontStyleProperty.DefaultMetadata.DefaultValue));
    public FontStyle ErrorFontStyle
    {
        get => (FontStyle)GetValue(ErrorFontStyleProperty);
        set => SetValue(ErrorFontStyleProperty, value);
    }

    public static readonly DependencyProperty ErrorFontWeightProperty = DependencyProperty.Register(nameof(ErrorFontWeight), typeof(FontWeight), typeof(TextInput), new PropertyMetadata(FontWeightProperty.DefaultMetadata.DefaultValue));
    public FontWeight ErrorFontWeight
    {
        get => (FontWeight)GetValue(ErrorFontWeightProperty);
        set => SetValue(ErrorFontWeightProperty, value);
    }

    public static readonly DependencyProperty ErrorForegroundProperty = DependencyProperty.Register(nameof(ErrorForeground), typeof(Brush), typeof(TextInput), new PropertyMetadata(ForegroundProperty.DefaultMetadata.DefaultValue));
    public Brush? ErrorForeground
    {
        get => (Brush?)GetValue(ErrorForegroundProperty);
        set => SetValue(ErrorForegroundProperty, value);
    }

    public static readonly DependencyProperty ErrorHorizontalContentAlignmentProperty = DependencyProperty.Register(nameof(ErrorHorizontalContentAlignment), typeof(HorizontalAlignment), typeof(TextInput), new PropertyMetadata(HorizontalContentAlignmentProperty.DefaultMetadata.DefaultValue));
    public HorizontalAlignment ErrorHorizontalContentAlignment
    {
        get => (HorizontalAlignment)GetValue(ErrorHorizontalContentAlignmentProperty);
        set => SetValue(ErrorHorizontalContentAlignmentProperty, value);
    }

    public static readonly DependencyProperty ErrorVerticalContentAlignmentProperty = DependencyProperty.Register(nameof(ErrorVerticalContentAlignment), typeof(VerticalAlignment), typeof(TextInput), new PropertyMetadata(VerticalAlignment.Center));
    public VerticalAlignment ErrorVerticalContentAlignment
    {
        get => (VerticalAlignment)GetValue(ErrorVerticalContentAlignmentProperty);
        set => SetValue(ErrorVerticalContentAlignmentProperty, value);
    }

    #endregion

    #region lccErrorTextBlock

    public static readonly DependencyProperty ErrorLineHeightProperty = DependencyProperty.Register(nameof(ErrorLineHeight), typeof(double), typeof(TextInput), new PropertyMetadata(TextBlock.LineHeightProperty.DefaultMetadata.DefaultValue));
    public double ErrorLineHeight
    {
        get => (double)GetValue(ErrorLineHeightProperty);
        set => SetValue(ErrorLineHeightProperty, value);
    }

    public static readonly DependencyProperty ErrorTextProperty = DependencyProperty.Register(nameof(ErrorText), typeof(string), typeof(TextInput), new PropertyMetadata(TextBlock.TextProperty.DefaultMetadata.DefaultValue));
    public string? ErrorText
    {
        get => (string?)GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
    }

    public static readonly DependencyProperty ErrorTextAlignmentProperty = DependencyProperty.Register(nameof(ErrorTextAlignment), typeof(TextAlignment), typeof(TextInput), new PropertyMetadata(TextBlock.TextAlignmentProperty.DefaultMetadata.DefaultValue));
    public TextAlignment ErrorTextAlignment
    {
        get => (TextAlignment)GetValue(ErrorTextAlignmentProperty);
        set => SetValue(ErrorTextAlignmentProperty, value);
    }

    public static readonly DependencyProperty ErrorTextTrimmingProperty = DependencyProperty.Register(nameof(ErrorTextTrimming), typeof(TextTrimming), typeof(TextInput), new PropertyMetadata(TextBlock.TextTrimmingProperty.DefaultMetadata.DefaultValue));
    public TextTrimming ErrorTextTrimming
    {
        get => (TextTrimming)GetValue(ErrorTextTrimmingProperty);
        set => SetValue(ErrorTextTrimmingProperty, value);
    }

    public static readonly DependencyProperty ErrorTextWrappingProperty = DependencyProperty.Register(nameof(ErrorTextWrapping), typeof(TextWrapping), typeof(TextInput), new PropertyMetadata(TextBlock.TextWrappingProperty.DefaultMetadata.DefaultValue));
    public TextWrapping ErrorTextWrapping
    {
        get => (TextWrapping)GetValue(ErrorTextWrappingProperty);
        set => SetValue(ErrorTextWrappingProperty, value);
    }

    public static readonly DependencyProperty ErrorsMaxLinesProperty = DependencyProperty.Register(nameof(ErrorsMaxLines), typeof(int?), typeof(TextInput), new PropertyMetadata(null, OnErrorTextMaxLinesProperty_PropertyChanged));
    public int? ErrorsMaxLines
    {
        get => (int?)GetValue(ErrorsMaxLinesProperty);
        set
        {
            SetValue(ErrorsMaxLinesProperty, value);
            Validate();
        }
    }
    private static void OnErrorTextMaxLinesProperty_PropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        if (source is TextInput TextInput)
        {
            TextInput.Validate();
        }
    }

    #endregion

    public static readonly DependencyProperty ValidatorProperty = DependencyProperty.Register(nameof(Validator), typeof(IRuleSetValidator<string?>), typeof(TextInput), new PropertyMetadata(null, OnValidatorProperty_PropertyChanged));
    public IRuleSetValidator<string?>? Validator
    {
        get => (IRuleSetValidator<string?>?)GetValue(ValidatorProperty);
        set
        {
            SetValue(ValidatorProperty, value);
            SetValidator(value);
        }
    }
    private static void OnValidatorProperty_PropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        if (source is TextInput textInput && e.NewValue is IRuleSetValidator<string?> validator)
        {
            textInput.SetValidator(validator);
        }
    }
    private void SetValidator(IRuleSetValidator<string?>? validator)
    {
        Validation = validator?.Validation;
        Errors = validator?.ValidationErrors ?? [];
    }

    public static readonly DependencyProperty ValidationProperty = DependencyProperty.Register(nameof(Validation), typeof(Func<string?, IEnumerable<string?>>), typeof(TextInput), new PropertyMetadata(null, OnValidationProperty_PropertyChanged));
    public Func<string?, IEnumerable<string?>>? Validation
    {
        get => (Func<string?, IEnumerable<string?>>?)GetValue(ValidationProperty);
        set
        {
            SetValue(ValidationProperty, value);
            Validate();
        }
    }
    private static void OnValidationProperty_PropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        if (source is TextInput textInput)
        {
            textInput.Validate();
        }
    }

    public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register(nameof(IsValid), typeof(bool), typeof(TextInput), new PropertyMetadata(true));
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public static readonly DependencyProperty ErrorsProperty = DependencyProperty.Register(nameof(Errors), typeof(ObservableCollection<string>), typeof(TextInput), new PropertyMetadata(null, OnErrorsProperty_PropertyChanged));
    public ObservableCollection<string> Errors
    {
        get => (ObservableCollection<string>)GetValue(ErrorsProperty);
        set
        {
            if (Errors is not null)
            {
                Errors.CollectionChanged -= Errors_CollectionChanged;
            }

            SetValue(ErrorsProperty, value);

            ArgumentNullException.ThrowIfNull(Errors);

            Errors.CollectionChanged += Errors_CollectionChanged;

            SetIsValidFromErrors();
        }
    }
    private void Errors_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        SetIsValidFromErrors();
    }
    private static void OnErrorsProperty_PropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        if (source is TextInput textInput)
        {
            if (e.OldValue is not null and ObservableCollection<string> previousCollection)
            {
                previousCollection.CollectionChanged -= textInput.Errors_CollectionChanged;
            }

            ArgumentNullException.ThrowIfNull(e.NewValue, nameof(Errors));

            if (e.NewValue is ObservableCollection<string> newCollection)
            {
                newCollection.CollectionChanged += textInput.Errors_CollectionChanged;
            }

            textInput.SetIsValidFromErrors();
        }
    }
    private void SetIsValidFromErrors() => IsValid = Errors is not null && !Errors.Any();

    public new static readonly DependencyProperty IsFocusedProperty = DependencyProperty.Register(nameof(IsFocused), typeof(bool), typeof(TextInput), new PropertyMetadata(false));
    public new bool IsFocused
    {
        get => (bool)GetValue(IsFocusedProperty);
        private set => SetValue(IsFocusedProperty, value);
    }

    public static readonly DependencyProperty InputCommandProperty = DependencyProperty.Register(nameof(InputCommand), typeof(ICommand), typeof(TextInput), new PropertyMetadata(null));
    public ICommand? InputCommand
    {
        get => (ICommand?)GetValue(InputCommandProperty);
        set => SetValue(InputCommandProperty, value);
    }

    public static readonly DependencyProperty InputCommandParameterProperty = DependencyProperty.Register(nameof(InputCommandParameter), typeof(object), typeof(TextInput), new PropertyMetadata(null));
    public object? InputCommandParameter
    {
        get => (object?)GetValue(InputCommandParameterProperty);
        set => SetValue(InputCommandParameterProperty, value);
    }

    public static readonly DependencyProperty ValidateCommandProperty = DependencyProperty.Register(nameof(ValidateCommand), typeof(ICommand), typeof(TextInput), new PropertyMetadata(null));
    public ICommand? ValidateCommand
    {
        get => (ICommand?)GetValue(ValidateCommandProperty);
        set => SetValue(ValidateCommandProperty, value);
    }

    public static readonly DependencyProperty ValidateCommandParameterProperty = DependencyProperty.Register(nameof(ValidateCommandParameter), typeof(object), typeof(TextInput), new PropertyMetadata(null));
    public object? ValidateCommandParameter
    {
        get => (object?)GetValue(ValidateCommandParameterProperty);
        set => SetValue(ValidateCommandParameterProperty, value);
    }

    public void Validate()
    {
        if (Validation is not null)
        {
            IEnumerable<string?> errors = Validation.Invoke(Text);

            if (ErrorsMaxLines is not null)
            {
                errors = errors.Take(ErrorsMaxLines.Value);
            }

            Errors.Clear();
            foreach (string? error in errors)
            {
                if (error is not null)
                {
                    Errors.Add(error);
                }
            }

            ValidateCommand?.Execute(ValidateCommandParameter);
        }
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

    private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        Validate();
        InputCommand?.Execute(InputCommandParameter);
    }

    private void InputTextBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox senderTextBox)
        {
            InputTextBox = senderTextBox;
        }
    }
}
