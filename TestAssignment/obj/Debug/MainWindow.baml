   M S B A M L   `   `   `  ����I  ETestAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestAssignmentTestAssignment  5   	       TestAssignment.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   .localclr-namespace:TestAssignment     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��800��5   	   $	��500��5	   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $��* �6   .+�5   
   �� $��0��6      HeaderTextBlockStyle#��[  5      $��
Input data��5      �� 5   
   $��1��6   #��[  5      $��
Import log��5      �� 5   
   $��2��6   $��0��5       $��	10,0,10,0q�5!       �� Orientation$ Vertical=�5"      .+�5#      ��   TextBlockStyle#��[ 6   $&�� Input full path or select a file��6@   � 5%      $��0,5,0,5q�6    5&      �� 5'      $��* �6'   �� 5(      $
��Auto �6'    5*      �� 5+      $��* �6$   �� 5,      $
��Auto �6$   .+�5/      �� -   5         ��Name$ FileNameTextBox��5/      $��0��50      $��0��51      $��Center=�52      ��53      �� *
FileName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  =� ErrorTemplate 56      Z� �� 58      $��0��6   $��1��59      $
��Auto��5:      $��	10,0,10,0q�5;      $	��...��5=        MetroButton#��[ 5>      ��5<      �� *SelectFileCommand+5>      �� 5@      $��1��6#   $��0��5A   #   $��2��5B   #   ��5C   #   ��  �� ElementName$ FileNameTextBox��	 �� Path$%	 (Validation.Errors).CurrentItem�5E      �� 5G      $
��Auto��6   $��10,20,10,10q�5H      $��Right=�5I      $�� Import ��5K      #��[ 5M      ��5J      �� *ImportCommand+{�5L      �� *FileNameIsCorrect+5M      5N      � 5Q   
   $��2��6   $��1��5R      $��	10,0,10,0q�5S       5T      �� 5U      $
��Auto �6    �� 5V      $��* �6    �� 5W      $
��Auto �6    .+�5Z      �� $��10q�6   #��[ 5[      ��5\      �� *
ResultText+�� 5^      $��1��6   y�6&   �� *	HasErrors+   BooleanToVisibilityConverter
 �� 	Converter#
 [ .+�5_      �� #��[ 6   $��Errors��6D   &   System.Windows.Controls.DataGrid  5`         AutoGenerateColumns .     
IsReadOnly . ��5b      �� *Errors+   Columns 5c      0  *System.Windows.Controls.DataGridTextColumn  5d      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6-      MaxWidth$	 100Q�5e   -      Header$ Account��5g   -     StandardColumnHeaderStyle   HeaderStyle# [ 5h   -      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5f   -   �� *	Account+   ElementStyle 5j      �� 5k   "    �� 
TargetType" ��6(   .�5l   &   ��  �� Property � �� �� Value$ Center=�6L   5m   #   5o        5q      $
 Auto 6-      MinWidth$	 100Q�5r   -   $	 200Q�5s   -   $ Description��5u   -   # [ 5v   -    .  5t   -   �� *Description+ 5x      �� 5y   "   " ��6(   .�5z   &   ��  � ��$ Center=�6L   5{   #   5}        5      $
 Auto 6-   $	 100Q�5�   -   $	 200Q�5�   -   $ Currency Code��5�   -   # [ 5�   -    .  5�   -   �� *CurrencyCode+ 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�        5�      $
 Auto 6-   $	 100Q�5�   -   $	 200Q�5�   -   $ Value��5�   -   # [ 5�   -    .  5�   -   �� *Value+ 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�        5�      $ * 6-   $ Validating Errors��5�   -   # [ 5�   -    .  5�   -   �� *Errors+ 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Center=�6L   5�   #   5�      5�      5�      5�      5�      5�      