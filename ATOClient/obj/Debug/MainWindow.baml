   M S B A M L   `   `   `  ����D  @ATOClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ATOClient	ATOClient  5   	       ATOClient.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ATOClient     5   	     � Title$  
MainWindow��5   	   .��5	      � -   5        $��MainGrid��5	      $
��auto��6    � ColumnDefinitions 5
   
   �� 5      -   5         �Name$ ColumnAllTables��5      $
��auto �66   $��25��6C   6S   �� 5      $
��auto �6   6.   �� 5      $	��150��6   60    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $��20 �6   6*   .+�5   
   o� $��0��6   $��0��6   $��3��6,   6B   9� 5   
   $��0��6   $��1��5      $��3��5      $��Right=�5      $	��Top=�5      
����� �$
��Left=�5       9� 
IsExpanded . ��5      ��  �� ElementName$ MainGrid�� �� Path$ Width�5      � 5   
   -   5        $��GrContentBase��5      $��0��6$   $��2��64    5      �� 5       6%   �� 5!      $��25 �6#   60    5#      �� 5$      $
��auto �6    60   �� 5%      6"   .+�5'      �� $��Все таблици��6   $��0��6+   $��0��6;    �� TextAlignment$ Center=�6H   6a   �� 5(      -   5        $��bAllTablesCollaps��5(      $��G��5)      $��1��5*      $��0��5+      6D   R� 5,      -   5        $��TreeViewTables��5,      $��0��5-      $��1��5.      $��2��5/      .@�51      Q� -   5        $��Alphabet��52      $#��Базовые таблицы��51      52   1   Q� 53      -   5        $	��UBD��54      $��УБД��53      54   ,   56      57      �� 58   
   $��5��6   $��2��6!   $��1��59      $��Stretch=�5:      $��Center=�63   �� 5<      -   5        $��
TabControl��5<   6   $��2��6   $��2��6)   6J   � 5=      -	   5        $��StatusPanel��5=      $��0��6+   $��3��6;   6J   5>      5?      