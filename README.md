# How-to-Apply-CellTemplate-and-EditTemplate-Based-on-RowIndex-in-SfTreeGrid
This example illustrates how to Apply CellTemplate and EditTemplate Based on RowIndex in SfTreeGrid

Typically, the templates are loaded based on the value of the underlying data object. In some cases, you need to load the template based on the row index. To accomplish this, we have defined a static SfTreeGrid property in both the selector classes and assigned SfTreeGrid in the MainWindow class.

  
 ```js
<Window.Resources>
    <local:CustomCellTemplateSelector x:Key="cellTemplateSelector" />
    <local:CustomEditTemplateSelector x:Key="editTemplateSelector"/>

    <DataTemplate x:Key="ComboBoxCellTemplate">
        <Grid>
            <syncfusion:ComboBoxAdv BorderBrush="Transparent" Background="Transparent" Grid.Column="1" 
                                    SelectedItem="{Binding SelectedComboItem}"
            ItemsSource="{Binding ComboBoxItems}" syncfusion:VisualContainer.WantsMouseInput="False"
            syncfusion:FocusManagerHelper.FocusedElement="True" />
        </Grid>
    </DataTemplate>

    <DataTemplate x:Key="TextBlockCellTemplate">
        <TextBlock VerticalAlignment="Center"
    Text="{Binding Path=FirstName}"/>
    </DataTemplate>
    
    <DataTemplate x:Key="ComboBoxEditTemplate">
        <Grid>
            <syncfusion:ComboBoxAdv BorderBrush="Transparent" Background="Transparent" Grid.Column="1" 
                                    SelectedItem="{Binding SelectedComboItem}"
                            ItemsSource="{Binding ComboBoxItems}" syncfusion:VisualContainer.WantsMouseInput="False"
                            syncfusion:FocusManagerHelper.FocusedElement="True" />
        </Grid>
    </DataTemplate>

    <DataTemplate x:Key="TextBoxEditTemplate">
        <TextBox Height="20"
    VerticalAlignment="Center" syncfusion:FocusManagerHelper.FocusedElement="True"
    Text="{Binding Path=FirstName}" />
    </DataTemplate>
</Window.Resources>
 ```

**C# code:**
 
 ```js
public MainWindow()
{
    InitializeComponent();
    CustomCellTemplateSelector.SfTreeGridCell = this.treeGrid;
    CustomEditTemplateSelector.SfTreeGridEdit = this.treeGrid;
}

public class CustomEditTemplateSelector : DataTemplateSelector
{
    public static SfTreeGrid SfTreeGridEdit { get; set; }
    public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
    {

        if (item == null)
            return null;
        var data = item as EmployeeInfo;
        var recordRowIndex = (SfTreeGridEdit.DataContext as ViewModel).Employees.IndexOf(data);
        var rowIndex = SfTreeGridEdit.ResolveToRowIndex(recordRowIndex);
        if (rowIndex == 1 || rowIndex == 3)
            return Application.Current.MainWindow.FindResource("ComboBoxEditTemplate") as DataTemplate;

        else
            return Application.Current.MainWindow.FindResource("TextBoxEditTemplate") as DataTemplate;
    }
}

public class CustomCellTemplateSelector : DataTemplateSelector
{
    public static SfTreeGrid SfTreeGridCell { get; set; }
    public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
    {
        if (item == null)
            return null;
        var data = item as EmployeeInfo;
        var recordRowIndex = (SfTreeGridCell.DataContext as ViewModel).Employees.IndexOf(data);
        var rowIndex = SfTreeGridCell.ResolveToRowIndex(recordRowIndex);
        if (rowIndex == 1 || rowIndex == 3)
            return Application.Current.MainWindow.FindResource("ComboBoxCellTemplate") as DataTemplate;

        else
            return Application.Current.MainWindow.FindResource("TextBlockCellTemplate") as DataTemplate;
    }
}
 ```

Image reference:
![image.png](https://support.syncfusion.com/kb/agent/attachment/article/15657/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIwNDI3Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.1E7443aJW6pCfU8BR96H7Uw_JeCa0GddT_NIqSD1nUk)


Take a moment to peruse the [WPF-SfTreeGrid Template Selector Documentation](https://help.syncfusion.com/wpf/treegrid/column-type#set-edittemplate-based-on-custom-logic), to learn more about template selector with examples.