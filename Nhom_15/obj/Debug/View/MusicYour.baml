   M S B A M L   `   `   `  ����B  >Nhom_15, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Nhom_15.ViewNhom_15.View  5      5clr-namespace:Nhom_15.ViewModelNhom_15.ViewModel  5          Nhom_15.View.MusicYour   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Nhom_15.View     5      5	ViewModelclr-namespace:Nhom_15.ViewModel     5        � DataContext  5
      %  Nhom_15.ViewModel.MusicYourVIew  5   
   .��5      �� .��5   
   � .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10,0,0,0q�62   .+�5      �� $��
Danh Sách��6   
�������$��25(�6@   $��DemiBold"�6N   �� 5      $��Của Bạn��6   ���#de3957$��25(�6@   $��DemiBold"�6N   $��5,0,0,0q�6d   5      �� 5      -   5         ��Name$ listview��5      $��Disabled=�5      $
��Left=�5      ���#252525$
��Auto��5      $	��790��5      ��5      �� *	YourMusic+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5      �� *SelectedProduct+��5      �� 5      .R�5      �� $
��Left=�6%   $	��110��6@   $	��100��6L   $��5q�6Y   .+�5      �� $��UniformToFill=�6=   $	��100��6U   $��60��6a   ��6$   �� *Image+6a   �� 5       $��12(�6D   $
��Bold"�6R   $��0,5,0,0q�6d   ��6(   �� *
TenProduct+6d   �� 5!      $��Center=�6S   $��10(�6p   $��0,0,0,5q�6~   ��6(   �� *Gia+ �� StringFormat$ {0:C}��6~   5"      5#      ��5%      �� 5&      .R�5'      � $
��1030��6$   5(      5*      5+      5,      5-      