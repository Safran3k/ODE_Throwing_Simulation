   M S B A M L   `   `   `  ����C  ?Throwing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ThrowingThrowing  5   	       Throwing.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Throwing     5   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1100��6)    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��510 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   .+�5      �� -   5        $��btnStart��5      $��Start��6<   $��10,10,10,9.6q�6L   $��40��6b   �� 5      -   5        $��btnReset��5      $��Reset��6<   $��10,10,10,9.6q�6L   $��40��6b   �� 5      -   5        $��btnClose��5      $��Close��6<   $��10,10,10,9.6q�6L   $��40��6b    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5         ��Name$ border1��5      $��1��6"   $
��1000��6/   $	��500��6<   ���	#FF4F4141$��5q�6b   ._�5      �� -   5         ��Name$ canvas��5      
�������.+�5      ��  �� Left$ 0��6   	 �� Bottom$	 0��6,   $	��215��6>   $	��150��6K   
�������
���   �$��10��5   7   
 �� StrokeLineJoin$
 Round=�6L   5      5      �� 5   
   -   5         ��Name$ 
stpControl��5   "   $��2��6   $ 
Horizontal=�66   $��47,0,-0.4,0q�6O   .+�5      �� -   5        $��lbInfo��5      $��0 0 5 0q�6"   $��24(�63   5       5!      5"      