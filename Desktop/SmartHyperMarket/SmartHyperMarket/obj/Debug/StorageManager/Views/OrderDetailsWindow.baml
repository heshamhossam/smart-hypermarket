   M S B A M L   `   `   `  ����  SmartHyperMarket>    8SmartHyperMarket.StorageManager.Views.OrderDetailsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  OrderWindow��5   	   $	��300��6   $	��300��6*    � 
ResizeMode$ CanMinimize=�66   .��5      � $��10, 10, 10, 10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6-   �� 5      $
��auto �6   6,    � ColumnDefinitions 5
   
   �� 5      $
��auto �6   6.   �� 5      $
��auto �6   6.   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0��69   .+�5      �� $ 
Horizontal=�6   .+�5      �� $	��ID:��6   �� 5      -   5        $��textBlockId��5      $��10, 0, 0, 0q�6/   5      �� 5      $ 
Horizontal=�6   $��0, 15, 0, 0q�62   .+�5      �� $��State:��6   �� 5      -   5        $��textBlockState��5      $��10, 0, 0, 0q�63   5      5      �� 5   
   $ Vertical=�6   $��0��6,   $��1��69   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Code:��6   �� 5      -   5        $��textBlockCode��5      $��10, 0, 0, 0q�62   5      �� 5       $ 
Horizontal=�6   $��0, 15, 0, 0q�62   .+�5!      �� $��Total Cost:��6   �� 5"      -   5        $��textBlockTotalcost��5"      $��10, 0, 0, 0q�67   5#      5$      �� 5'   
   -   5        $��stackPanelOrderProducts��5'   ,   $ Vertical=�6   $��1��6K   $��0��6X   $��2��6h   $��0, 20, 0, 0q�6|   .+�5(      �� $��	Products:��6   $
��Left=�6(   $	��Top=�6C   $��57��6[   5)      5,      5-      