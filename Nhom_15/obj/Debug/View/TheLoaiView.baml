   M S B A M L   `   `   `  ����B  >Nhom_15, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nhom_15.ViewNhom_15.View  5      5clr-namespace:Nhom_15.ViewModelNhom_15.ViewModel  5          Nhom_15.View.TheLoaiView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Nhom_15.View     5      5	ViewModelclr-namespace:Nhom_15.ViewModel     5        � DataContext  5      (  "Nhom_15.ViewModel.TheLoaiViewModel  5   
   .��5      �� .��5   
   � ���#252525.+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10 0 0 0q�66   .+�5      �� $��Thể ��6    
�������$��25(�6?   $��DemiBold"�6M   �� 5      $�� Loại��6    ���#de3957$��25(�6B   $��DemiBold"�6P   5      �� 5      -   5        $��
lvProducts��5      ��6-   �� *GroupedProductsView+��5      �� 5      .R�5      �� $ 
Horizontal=�6)   $��5q�6B   .+�5   "   �� $��UniformToFill=�6A   $	��100��6Y   $��60��6e   $��5q�6q   ��6(   �� *Image+6q   �� 5   "   $ Vertical=�6-   $��5q�6D   .+�5   &   �� $��12(�6L   $
��Bold"�6Z   $��0,5,0,0q�6l   ��60   �� *
TenProduct+6l   �� 5   &   $
��Left=�6[   $��10(�6v   $��0,0,0,5q�6�   ��60   �� *Gia+ �� StringFormat$ {0:C}��6�   5   #   5      5        �� 
GroupStyle 5"      (  "System.Windows.Controls.GroupStyle  5#         ContainerStyle 5$      �� 5%   "    �� 
TargetType" ��6(   .�5&   &   ��  �� Property � �� �� Value 5'   *   �� 5(   .   .R�5)   2   9�  9� 
IsExpanded . ��5*   6   �� 5+   :   $ 
Horizontal=�6E   .+�5,   >   �� $
��Bold"�6^   
�������$��22(�6�   $��Bottom=�6�   ��6H   �� *Name+6�   �� 5-   >   $��22(�6c   
��� � �$
��Bold"�6�   $��Italic$�6�   $��10,0,0,0q�6�   $��Bottom=�6�   ��6H   �� *	ItemCount+6�   �� 5.   >   $�� Bài ��6H   $��22(�6U   
�������$��Italic$�6w   $��Bottom=�6�   5/   ;   .��51   6   �� 52   3   53   /   55   '   56   #   58      5:      5;      5<      5=      5>      