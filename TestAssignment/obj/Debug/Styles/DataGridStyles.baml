   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries   StandardColumnHeaderStyle �� 
TargetType=   7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  AccentBrush �� 
TargetType ��Name ��Name J� SnapsToDevicePixels �� Triggers	 P� Value
 P� Property �� 
TargetName  
WhiteBrush ]� 
Conditions �� Property �� Value  
GrayBrush8 �� TextAlignment  DataGridRowStyle)  #System.Windows.Controls.DataGridRow �� 	Resources*  $System.Windows.Controls.DataGridCell �� Triggers $  MetroDataGrid.HighlightTextBrush ^� 
Conditions �� Binding �� Path �� RelativeSource �� AncestorType&   System.Windows.Controls.DataGrid 5 1MetroDataGrid.InactiveSelectionHighlightTextBrush?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions ��Name?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter#   RowDetailsScrollingConverter  �� 	Converter:  4System.Windows.Controls.Primitives.DataGridRowHeader7	  1System.Windows.Controls.DataGridHeadersVisibility
! 	  Row!"   HeadersVisibilityConverter  PopupMenuControlTemplate   MetroDataGrid.HighlightBrush 	 AccentColorBrush 1
 -MetroDataGrid.InactiveSelectionHighlightBrush ) %MetroDataGrid.MouseOverHighlightBrush# �� BasedOn  AccentColorBrush4  ExpressDataGridRowStyle&
   System.Windows.Media.TextOptions�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      6W     5      %c  &	        &	 �    7  '  S    7 �� 5      "   6.   .�5   
   ��  �@J�SnapsToDevicePixels . 60   �� 5   
    � ��$ 0��6%   �� 5   
    � ��$ 25��6&   �� 5   
    � ��
 �����6'   �� 5	   
    �@�Cursor$
 Hand��6#   �� 5
   
    � ��$ Center=�67   �� 5   
    � ��$ Center=�65   �� 5   
    � ��$ 10,4,4,7q�6$   �� 5   
    � ��$ 0,0,0,0q�6#   �� 5   
    � ��$ 0,0,0,1q�6,   �� 5   
    � ��
 �   �6(   �� 5   
    � ��# �  6'   �� 5   
    � �� 5      �� 5      "   6"   .R�5      � .+�5      �� $ BackgroundBorder��6!   #��z��5   !   #��z��5   !   #��z��5   !   �� 5      $ HeaderContent��6+   #��z��5   +   #��z��5   +   #��z��5   +   #��z��5   +   #��z��5   +   ��. # z 5!   +   5#       5$      P� 5%      	 6;   Z� 
 �@  SortDirection. �5&      �� $ BackgroundBorder��6%   # �  6Y    � ��5'      ]� 5(       5)      �� 5*   "    �@J�IsMouseOver . 6C   �� 5+   "    6E   Z�  �@  SortDirection./�5-      �� $ BackgroundBorder��6%   # �  6Y    � ��5.      P� 50      
 � {�	 .  . �51      �� # � ��6;    � ��52      54      56      �� 57   
    � �� 58      �� 59      .R�5:      �� $��11(�6    $��SemiBold"�5;       $ Center=�5=       $
��Wrap=�5>       ��5<       �� 5>       5@      5B      5C      �� 5E      "  6%    5F   
   ���� 5G      '        "  6    5H      P� 5I      
 �@ 
IsSelected	 . . �5J      ��  � ��# �  67   5K      ^� 5N       5O      �� 5P       6(   �� $ SelectionUnit� �� *FindAncestor+"   FullRow6�   �� 5Q       6(   �� $ 
IsSelected� �� *Self+ true6r   .0�5S      ��  � ��
 ���� 67   �� 5T       � ��
 ���� 68   �� 5U       � ��# �  67   5V      ]� 5Y       5Z      �� 5[       �@ 
IsSelected . 6>   �� 5\       �@��IsSelectionActive .  6N   ./�5^      ��  � ��
 ���� 67   �� 5_       � ��
 ���� 68   �� 5`       � ��# �  67   5a      5d      5e      .�5g   
   ��  � ��$ 0,0,0,0q�6#   �� 5h   
    � ��
 ���� 6(   �� 5i   
    � ��# �  6'   �� 5j   
    � ��$ 1q�6,   �� 5k   
    � �� 5l      �� 5m      "  6"   .R�5o      �� $ 
DGR_Border��6   #��z��5p      #��z��5q      #��z��5r       . ._�5t         5u      �� 5v   "   $
��Auto �63   �� 5w   "   $��* �63    5y      �� 5z   "   $��* �60   �� 5{   "   $
��Auto �60   .+�5�      �� $ ContentControl��6-   $��1��6E   .��5�   "     #��z 69   # z 6c   5�        5�      $��1��67   $��1��5�   7   #y�z 5�   7    5�   7   �� *AreRowDetailsFrozen+# Z #  Z  �� "  5�   7     5�      $��2��60   $ Vertical=�5�   0   y�5�   0   �� *HeadersVisibility+# Z! #  Z"  �� "  5�      5�       5�      P� 5�      
 �@ 
IsSelected	 . . �5�      �� $ ContentControl��6%   8    � ��6U   5�      5�      5�       5�   
   ]� 5�       5�      �� 5�       �@ 
IsSelected . 66   �� 5�       �@J�IsMouseOver .  67   �� 5�       �@��IsSelectionActive . 6F   ./�5�      ��  � ��# �  6/   �� 5�       � ��# � 	 60   5�      ]� 5�       5�      �� 5�       �@ 
IsSelected . 66   �� 5�       �@J�IsMouseOver .  67   �� 5�       �@��IsSelectionActive .  6F   ./�5�      ��  � ��# � 
 6/   �� 5�       � ��# � 	 60   5�      ]� 5�       5�      �� 5�       �@ 
IsSelected . 66   �� 5�       �@J�IsMouseOver . 67   ./�5�      ��  � ��# �  6/   �� 5�       � ��# � 	 60   5�      ]� 5�       5�      �� 5�       �@ 
IsSelected .  66   �� 5�       �@J�IsMouseOver . 67   ./�5�      ��  � ��# �  6/   �� 5�       � ��
 ���� 60   5�      ^� 5�       5�      �� 5�       6    �� $ 
IsSelected� �� $ DataGridRowL� true6~   �� 5�       6    �� $ IsMouseOver� �� *Self+ true6k   .0�5�      ��  � ��# � 	 6/   �� 5�       � ��
 �  ��60   �� 5�       � ��$ 3q�64   5�      5�      �� 5�      8#   "  69   .�5�   
   ��  �@�OverridesDefaultStyle . 62   �� 5�   
     �@ AlternatingRowBackground# �  65   �� 5�   
    �@ RowStyle# �  6%   �� 5�   
    �@ GridLinesVisibility$ Vertical=�60   �� 5�   
    �@ HeadersVisibility$ Column=�6.   �� 5�   
    �@ SelectionMode$ Extended=�6*   �� 5�   
    �@ SelectionUnit$ FullRow=�6*   �� 5�   
    �@
 TextFormattingMode$ Display=�6;   5�      5�      