   M S B A M L   `   `   `  ����  KursCarShop+    %KursCarShop.Reports.CarsByPriceWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  CarShop��5   	   $	��450��6   $	��750��6&    � WindowStyle$ ThreeDBorderWindow=�62    � 	Resources 5       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '��       '  �     '  6    �� 5   
   " ��6   .�5      ��  � �� �#3498db6+   �� 5       � ��$ 14(�6)   �� 5	       � ��$ 5q�6(   �� 5
       � ��$	 0,2q�6'   �� 5       � ��$	 700��6&   5      �� 5   
   "  6   .�5      ��  � �� �#3498db6,   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       �@ CanUserAddRows .  6/   �� 5       �@ CanUserDeleteRows .  62   �� 5       �@ AutoGenerateColumns .  64   �� 5       � ��$	 700��6&   5      �� 5   
   "  6   .�5      ��  � �� �#3498db6+   �� 5       � ��
 �����6+   �� 5       � ��$ 5q�6(   5      5      .��5      � .+�5    
   �� .+�5!      �� -   5        $��
Найти��5!      6%   �� 5#       �� Orientation$ 
Horizontal=�6   $��	30,0,0,10q�62   .+�5$      �� $��Минимум:��6   $
��Bold"�6,   $��80��6>   $��Center=�6I   �� 5%      -   5        $��
minTextBox��5%      $	��150��6,   $	��5,0q�68   5&      �� 5(      $ 
Horizontal=�6   $��	30,0,0,10q�62   .+�5)      �� $��Максимум:��6   $
��Bold"�6-   $��80��6?   $��Center=�6J   �� 5*      -   5        $��
maxTextBox��5*      $	��150��6,   $	��5,0q�68   5+        50      -   5          Name$ CarsByPriceDataGrid��50      $	��300��64      Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Цена��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 230 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Price+6Q     53      $	 Цвет��6)   $	
 230 6R    67   �� *Colour+6R     54      $	 Доступность��6)   $	
 230 6c    6>   �� *AvailabilityText+6c   56      57      58      59      