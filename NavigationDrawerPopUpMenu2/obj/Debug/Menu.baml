   M S B A M L   `   `   `  ����U  QNavigationDrawerPopUpMenu2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NavigationDrawerPopUpMenu2NavigationDrawerPopUpMenu2  5   	   %    NavigationDrawerPopUpMenu2.Menu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:NavigationDrawerPopUpMenu2     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��708.589��5      $��1159.905��6+   
�������  � 
ResizeMode$  NoResize=�6O    � WindowStartupLocation$ CenterScreen=�6e    � WindowStyle$
 None=�6�    � 	Resources 5	         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5
   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5      .��5      � ���	#FFDEDEDE.+�5    
   � -   5         �Name$ GridMain��5       $��Right=�6!   $��Bottom=�6=   $	��557��6X   $	��956��6e   $��0,0,44,37.8q�6q   .+�5!      � -   5        $ Gird2��5!      $
��Left=�6"   $	��438��6=   $��	10,10,0,0q�6J   $	��Top=�6]   $	��657��6u   5"      � 5#   
   $��60��6   $	��Top=�6   ���	#FF5C99D6	 J� Effect	 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%      
   
BlurRadius$
 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5'      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5(      �� $
��User��6   $��Center=�6(   $��16(�6C   '  !MaterialDesignThemes.Wpf.PopupBox  5)         PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .  $��10q�6e      PopupContent. 5*      �� $	��150��6!   .+�5,      �� $
��Help��6!   �� 5-      �� 5.      -   5        $��Salir��5.   !   61   5/      50      51      52      � 53   
   -   5        $ GridMenu��53      $	��155��6!   $
��Left=�6-   ���	#FF31577E	 54        55      $
 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�57      �� .+�58      � $
��58.8��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�68   z�59      V� 5:      .~�5;      �� �� 5<      �� 5=      T� 5>      5?      .+�5A      �� -   5         ��Name$ ButtonOpenMenu��5A      $��60��65   $��60��6A   $��5q�6L   $��Right=�6W   $	��Top=�6s    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5B      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�62   $��25��6>   $��25��6I   5C      �� 5D      -   5        $ ButtonCloseMenu��5D      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��5q�6d   $��Right=�6o   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5E        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5F      �� 5H      $
��33.6��6   $��Bottom=�6*   $��
0,0,0,46.4q�6E   5I      �� 5J      -   5         ��Name$ ListViewMenu��5J      ���	#FF5C99D6$��Disabled=�6H   .@�5K      �� -   5         ��Name$ ItemHome��5K   #   $��60��65   .��5L      �� $ 
Horizontal=�6%   .+�5M        $
 Apps=�66   $��25��6B   $��25��6N   $��10q�6Y   �� 5N      $
��MENU��6(   $��Center=�64   $��20 10q�6O   5O      5P      �� 5Q      -	   5        $ 
ItemLexico��5Q   #   $��60��67   .��5R      �� $ 
Horizontal=�6%   .+�5S        $ Sword=�66   $��25��6C   $��25��6O   $��10q�6Z   �� 5T      $��Léxico��6(   $��Center=�66   $��20 10q�6Q   ���	#FFE2E8EE$��16(�6w   5U      5V      �� 5W      -
   5        $ itemSintactico��5W   #   $��60��6;   .��5X      �� $ 
Horizontal=�6%   .+�5Y        $ Ticket=�66   $��25��6D   $��25��6P   $��10q�6[   �� 5Z      $��Sintáctico��6(   $��Center=�6:   $��20 10q�6V   ���	#FFC7CFD7$��16(�6|   5[      5\      �� 5]      $��60��6#   .��5^      �� $ 
Horizontal=�6%   .+�5_        $ Message=�66   $��25��6E   $��25��6Q   $��10q�6\   �� 5`      $��
Semántico��6(   $��Center=�69   $��20 10q�6U   ���	#FFBECAD6$��16(�6{   5a      5b      5c      5d      5e      5f      5g      