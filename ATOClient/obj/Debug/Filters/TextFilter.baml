   M S B A M L   `   `   `  ����D  @ATOClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ATOClient	ATOClient  5          ATOClient.TextFilter   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ATOClient     5      -   5        
�������  � 	Resources  5
         
collection��%   &	        �� 5   
   64   5      .��5      �� .+�5   
   �� $��Sort Acs��6   6&   �� 5   
   $��	Sort Desc��6   6'   �� 5   
   $	��230��6   $
��Auto=�5      $��Visible=�5      .��5   
   &   System.Windows.Controls.DataGrid  -   5        $��FilterTable��5         AutoGenerateColumns .     SelectionMode$ Single=�5   1   ��5      ��  �� Source# [     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5   "   ��  d� 	IsChecked 6+   ��  �� Path$ IsCheked� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�5      5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6*   �� $
 Name�$ TwoWay=�$	 PropertyChanged=�6z   5       5!      �� 5"   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5#      �� -   5        $��bCancel��5#   (   $��Отменить��6   69   �� 5$      -   5        $	��bOk��5$   )   $��Применить��6   66   5%      5&      5'      