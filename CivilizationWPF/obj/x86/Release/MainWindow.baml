   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35eDclr-namespace:System.Windows.Media.Effects;assembly=PresentationCoreSystem.Windows.Media.Effects   CivilizationWPF    CivilizationWPF.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     UeffectDclr-namespace:System.Windows.Media.Effects;assembly=PresentationCore     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      c _Microsoft.Expression.Effects, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ee4http://schemas.microsoft.com/expression/2010/effects  -     � Title$  Civilization��$	��738��$
��1366�� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=� � WindowStyle$
 None=�$
��1366��$
��1366��$	��738��$	��738�� � Left$ 0��
 � Top$ 0�� � Topmost .  {�.  J� IsManipulationEnabled .   � DataContext �� 	 � 	Resources	    	textBrush
 �� EndPoint �� 
StartPoint � Color � Offset  roundButton �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState �� RadiusY �� RadiusX 
� GradientOrigin 
� RadiusY 
� RadiusX J� Effect3   -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius J� SnapsToDevicePixels �� Triggers P� Property P� Value  textBlock_chTitle  �� TextAlignment  textBlock_enTitle��%_  &	        &	 X     7   &	 �    7   &	 y    7   �� $
 1,0.5&�$ 0,0.5&�.��� $ Black��$ 0Q�� $ SaddleBrown��$ 1Q��� " ��.���  � �� �� " �� ���� OnMouseEnter1 .R��    CommonStates��.   
Normal��  	MouseOver��  Pressed��  Disabled��.+��� $
 27.5��$
 27.5��$��0����
� $ 	0.35,0.15&�$	 0.5Q�$	 0.5Q�.��� $ White��$ 0Q�� $ #deb887��$ 1Q�   $ 10Q��� #��z����. # z #��z�� P�  �@J�	IsFocused . P�  �@��IsDefaulted . P�  �@J�IsMouseOver . P�  � �� . P�  � {� .  ��  � ��$ 55����  � ��$ 55����  � ��$ 10q���  � ��$
 Bold"���  � ��8   -   �� 8��  $	��124��$��70(�$  Center=�$��Center=�$��212,131,195,422q�$��生  存  下  去��$��Center=�$	��789��$
��Bold"�$��Italic$�$��Normal&�$
��None=�   �� $��70(�$��Normal&�$��Italic$�$
��Bold"�8��  $	��117��$��Center=�$��212,263,195,297q�$��LET ME SURVIVE��$  Center=�$
��None=�$��Center=�$	��789��   .��� ! � ColumnDefinitions! �� $
��138* ��� $��1206* �	   ComboBoxBackGround��%c   &	       �� $
 1,0.5&�$ 0,0.5&�.��� $ Cornsilk��$ 0Q�� $ 	BurlyWood��$ 1Q�.+��� -   $��stackPanel1��" �� Orientation$" Vertical=�$	��687��$��Center=�$��Center=�$��
16,12,16,0q�$	��106��.+��� -   $��button_Start��#���  $��Start���� -   $��button_Configure��#���  $��Create���� -   $��button_Pause��#���  $��Pause���� -   $��button_Reset��#���  $��Reset���� -   $��button_Save��#���  $
��Save���� -	   $��button_Load��#���  $
��Load���� -
   $��button_GameInfo��#���  $��12(�$��Normal&�.���� .+��� -   # ��Name$# textblock_GameInfo1��$
��Game��$��12(�$��Center=��� -   $# textblock_GameInfo2��$
��Info��$��12(�$��Center=��� -   $��button_Exit��#���  $
��Exit���� -   $��TextBlock_SpeedControl��#��[  $��23��$��Center=�$��Speed Control��$
��Bold"��� -   $��slider_SpeedControl��$��23��$��5q�$	��100��$ � Maximum$	$ 100Q�% � SmallChange$% 10Q�& � LargeChange$& 10Q�
����������� $
 1,0.5&�$ 0,0.5&�.��� $ Cornsilk��$ 0Q�� $ 	BurlyWood��$ 1Q��� -   $��comboBox_Language��$��23��#��[ $��5q�$��70��.@��� $��中文��#��[  #��[ �� $��English��#��[  #��[ �� -   $��border1��$��5q�$��0,12,0,0q�$��1��$	��687��$
��Left=�$	��Top=�$
��1206������ $
 1,0.5&�$ 0,0.5&�.��� $ 	#5300FFF8��$ 0Q�� $ 	#E00064FF��$ 1Q�._�� -   $��PictureGrid��
������ ' � ShowGridLines' .  ���� *BorderThickness+( �� Source$( border1��.+��� #��[  $	��124��$��70(�$  Center=�$��Center=�$��212,131,195,422q�$��生  存  下  去��$��Center=�$	��789��$
��Bold"�$��Italic$�$��Normal&�$
��None=�   �� $��70(�$��Normal&�$��Italic$�$
��Bold"�#��[  $	��117��$��Center=�$��212,263,195,297q�$��LET ME SURVIVE��$  Center=�$
��None=�$��Center=�$	��789��   ���� $
 1,0.5&�$ 0,0.5&�.��� $ 	#FFDCF6F6��$ 0Q�� $ 	#FF50FFFF��$ 1Q�