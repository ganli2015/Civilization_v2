   M S B A M L   `   `   `  ����   CivilizationWPF#    CivilizationWPF.ConfigureForm   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _Microsoft.Expression.Effects, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ee4http://schemas.microsoft.com/expression/2010/effects  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  -     � Title$  ConfigureForm��$	��300��$	��300�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�$��3q�����  �� EndPoint$	 1,1&� �� 
StartPoint$	 0,0&�.���  � Color$ Cornsilk�� � Offset$ 0Q�� $ 	BurlyWood��$ 1Q� � 	Resources    	textBrush3  -System.Windows.Media.Effects.DropShadowEffect  CheckedEffect   
BlurRadius	   Color  
NullEffect
   ShadowDepth  RadioButtonStyle1 �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState �� RadiusY �� RadiusX 
� GradientOrigin 
� RadiusY 
� RadiusX J� SnapsToDevicePixels �� Triggers P� Property P� Value��%  &	        &	 X     &	 u     &	 �     7   �� $ 1,0.5&�$ 0,0.5&�.��� $ Black��$ 0Q�� $ SaddleBrown��$ 1Q�  $ 20Q�$	 DarkBlue��  $ 0Q�$
 0Q�$	 Transparent���� " 	�.���  � �� �� " 	� ���� OnMouseEnter1 .R��    CommonStates��.   
Normal��  	MouseOver��  Pressed��  Disabled��.+��� $ 20��$ 20��$��0����
� $ 	0.35,0.15&�$	 0.5Q�$	 0.5Q�.��� $ White��$ 0Q�� $ #deb887��$ 1Q��� $��Center=�$��Center=���. # z ��  � ��$ 40����  � ��$ 40����  � ��$ 10q���  � ��$
 Bold"���  � ��8    P�  �@d�	IsChecked$
 TrueY�. ���  �@J�Effect# �  P�  �@d�	IsChecked$ FalseY�. ���  �@J�Effect# �  ���� $ 1,0.5&�$ 0,0.5&� �� Opacity$ 1Q�.��� $ 	LightBlue��$ 0Q�� $ 	#E00064FF��$ 1Q�.���  � RowDefinitions �� $
��235* ��� $	��26* �.+�� -   $��
WrapPanel1��$��0��.+�	� -   $��checkBox_Human��#���  $��Human��$��15q�	� -   $��checkBox_Grass��#���  $��Grass��$��15q�	� -   $��checkBox_Water��#���  $��Water��$��15q�	� -   $��checkBox_Desert��#���  $��Desert��$��15q�	� -   $��checkBox_Forest��#���  $��Forest��$��15q�	� -   $��checkBox_Mountain��#���  $��Mountain��$��15q�	� -	   $��checkBox_Ice��#���  $	��Ice��$��15q��� -
   $��button_exit��$
��Back��#��[  $��1��$��23��$
��Left=�$��0,3,0,0q�$	��Top=�$��75����
� $ 	0.35,0.15&�$	 0.5Q�$	 0.5Q�.��� $ White��$ 0Q�� $ #deb887��$ 1Q�