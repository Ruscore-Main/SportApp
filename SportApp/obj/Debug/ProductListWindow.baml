   M S B A M L   `   `   `  ����C  ?SportApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SportAppSportApp  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6.        SportApp.ProductListWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SportApp     5   	   6sys&clr-namespace:System;assembly=mscorlib     6.   -   5          � Title$  ProductListWindow��5   	   $	��450��6#   $	��800��60    � 	Resources 5	         NullImg��%N   &	        ��5
   
   0,pack://application:,,,/Resources/picture.png��6S   5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*   .+�5   
   � $��0��6   ���	#FF76E383.+�5      �� $��Center=�6   $��Center=�66    �� Orientation$ 
Horizontal=�6Q   .+�5      �� $��Resources/logo.png��6   �� 5      $��Center=�6   
�������.��6F   ООО "Спорт"6S   5      5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5      �� $��Center=�6   Поиск:6<   �� 5      -   5         ��Name$ 	TxtSearch��5   0   $	��150��6   $
��10,0q�6"   6i   �� 5      -   5         ��Name$ CmbSort��5   b   $	��120��6    �� SelectedIndex$ 0��6#   .@�5      �� .��6   По возрастанию6/   �� 5      .��6   По убыванию6,   5       �� 5!      -   5        $ 	CmbFilter��5!   r   $	��120��6   $
��10,0q�6#   $ 0��61   .@�5"      �� .��6   Все диапазоны6/   �� 5#      .��6   	0-9,99%6(   �� 5$      .��6   	10-14,99%6*   �� 5%      .��6   15% и более6,   5&      �� 5(      -   5         ��Name$ TxtAmountElemnts��5(      *(Общее кол-во записей: N6K   5)      �� 5+   
   -   5         ��Name$ ListProduct��5+       $��2��6   $��Disabled=�65   ��5,      �� 5-      .R�5.      � 	 � Orientation$	 
Horizontal=�6    $��Center=�69   $��Center=�6V   6s   5/      ��52      �� 53      .R�54      �� 
���   �$��2q�61   $��10q�6E   ._�55      �� $ 
Horizontal=�6%   $	��550��6>   $	��180��6J   $��Center=�6W   $��Center=�6r   .+�56      �� $	��200��6$   $��Uniform=�6c   $��10q�6u   ��60   �� *
GetImage+
 �� FallbackValue$
 NullImg��6�   �� 57      $ Vertical=�6)   $��Center=�6@   $��Center=�6]   .+�58   "   �� $
��Bold"�6,   ��6>   �� *ProductName+59   #   �� 5:   "   $
��Wrap=�6P   $	��250��6d   ��6,   �� *ProductDescription+6u   �� 5;   "   ��6,   �� *GetManufacturer+6O   �� 5<   "   $ 
Horizontal=�6-   $��Center=�6F   $��Center=�6c   .+�5=   &   �� 	Цена:67   �� 5>   &   $��Strikethrough{�6M   ��60   �� *ProductCost+6o   �� 5?   &   ��60   �� *
GetCurCost+6O   5@   #   5A      �� 5B      5D      �� 5F      $��10q�6(   $��Center=�6�   $��Center=�6�   ��64   �� *ProductDiscountAmount+��6[   �� *GetBackgroundDiscount+6�   5G      5H      5I      5K      5L      5M      