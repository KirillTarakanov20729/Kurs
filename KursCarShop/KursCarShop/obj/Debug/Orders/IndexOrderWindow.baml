   M S B A M L   `   `   `  ����  KursCarShop)    #KursCarShop.Orders.IndexOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  CarShop��5   	   $	��450��6   $	��750��6&    � WindowStyle$ ThreeDBorderWindow=�62    � 	Resources 5       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '��       '  �     '  6    �� 5   
   " ��6   .�5      ��  � �� �#3498db6+   �� 5       � ��$ 14(�6)   �� 5	       � ��$ 5q�6(   �� 5
       � ��$	 0,2q�6'   �� 5       � ��$	 700��6&   5      �� 5   
   "  6   .�5      ��  � �� �#3498db6,   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       �@ CanUserAddRows .  6/   �� 5       �@ CanUserDeleteRows .  62   �� 5       �@ AutoGenerateColumns .  64   �� 5       � ��$	 700��6&   5      �� 5   
   "  6   .�5      ��  � �� �#3498db6+   �� 5       � ��
 �����6+   �� 5       � ��$ 5q�6(   5      5      .��5      � .+�5    
   �� .+�5!      �� -   5        $!��Добавить заказ��5!      6.   �� 5"      -   5        $!��Изменить заказ��5"      6.   �� 5#      -   5        $��Удалить заказ��5#      6-   �� 5$      -   5        $��Закрыть��5$      6'     5&      -   5          Name$ orderDataGrid��5&      $	��300��6.      Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 115 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *id+6L     5)      $ Машина��6)   $		 115 6_   
 69   �� *Car.DisplayString+6_     5*      $ Клиент��6)   $		 115 6X   
 69   �� *
Client.FIO+6X     5+      $ Сотрудник��6)   $		 115 6]   
 6<   �� *Employee.FIO+6]     5,      $ Статус��6)   $		 115 6X   
 69   �� *
StatusText+6X     5-      $ Дата��6)   $		 115 6Y   
 67   �� *FormattedDate+6Y   5/      50      51      52      