   M S B A M L   `   `   `  ����N  JWindowsServicesTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WindowsServicesToolWindowsServicesTool  5   	   $    WindowsServicesTool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WindowsServicesTool     5   	     � Title$  Services Tool��5   	   $	��225��6   $	��280��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N    � WindowStyle$ ThreeDBorderWindow=�6s    � Icon$ Images/pc-settings.png��6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   $	��188��6*   �� 5      $��23��6   $
��Auto �6+    � ColumnDefinitions 5   
   �� 5      $	��259 �6   �� 5      .+�5   
   �� $��Current Status:��6   $
��Left=�6*   $��	10,72,0,0q�6E   $	��Top=�6X   $��26��6p   $��88��6|   �� 5   
   -   5         ��Name$ 	Statuslbl��5      $�� ��6#   $
��Left=�6.   $��
103,72,0,0q�6I   $	��Top=�6]   $	��154��6u   $��26��6�   �� 5   
   $��Service Name:��6   $
��Left=�6(   $��	10,41,0,0q�6C   $	��Top=�6V   $��88��6n   $��26��6y   �� 5   
   -   5        $ ServiceNamelbl��5      $�� ��6(   $
��Left=�63   $��
103,41,0,0q�6N   $	��Top=�6b   $	��154��6z   $��26��6�   �� 5   
   $
��PID:��6   $
��Left=�6   $��	10,10,0,0q�6:   $	��Top=�6M   $��88��6e   $��26��6p   �� 5   
   -   5        $ PIDlbl��5      $�� ��6    $
��Left=�6+   $��
103,10,0,0q�6F   $	��Top=�6Z   $	��154��6r   $��26��6~   �� 5   
   -   5         ��Name$ StopServiceBtn��5      $��Stop Service��6)   $
��Left=�6@   $��
10,103,0,0q�6[   $	��Top=�6o   $	��242��6�   $��35��6�   6�   �� 5   
   -   5        $ StartServiceBtn��5      $��Start Service��6*   $
��Left=�6B   $��
10,143,0,0q�6]   $	��Top=�6q   $	��242��6�   $��35��6�   6�   5      5      