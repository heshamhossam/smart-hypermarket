   M S B A M L   `   `   `  ����  SmartHyperMarket8    2SmartHyperMarket.DataEntryManager.Views.ShowOffers   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  
ShowOffers��5      .��5
      �� 
�������.+�5   
   �� 
������� �� Orientation$ 
Horizontal=�6(   .+�5      �� -   5        $��buttonEditOffer��5   K   $
��Edit��6   $��38��6$   $
��Left=�60   $	��Top=�6b   $��98��6z   6�   �� 5      -   5        $��buttonDeleteOffer��5   M   $��Delete��6   $��38��6&   $
��Left=�62   $	��Top=�6f   $��98��6~   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��offersListGrid��5         AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Teaser��6%    65   �� *Teaser+  5      $ Price��6%    64   �� *Price+5      5      5      