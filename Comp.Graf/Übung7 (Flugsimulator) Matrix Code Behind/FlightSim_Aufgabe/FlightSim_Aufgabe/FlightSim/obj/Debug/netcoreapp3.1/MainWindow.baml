   M S B A M L   `   `   `  ����  	FlightSim    FlightSim.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  Window1��5      $	��300��6   $	��600��6"   
�������.��5      � .+�5   
   '� -   5        $��
viewport3D��5       '� Camera 5      y� 5      -   5        matrixCamera��5      x�5      3  -System.Windows.Media.Media3D.ModelUIElement3D  5         Model 5      h� 5      .��5      t�  t� 	Direction$ 1,-1,05�6/   � 5       j� 	Transform 5   "   Y� 5   &   .�5   *   S�  S� OffsetX$ -5000Q�6?    S� OffsetZ$ +5000Q�6O   �� 5   *    �� ScaleY$ 3Q�6;   5   '    � Material 5   "   u� 5   &   -   5        diffuseMaterial��5   6   	 � BackMaterial	 5   "   �� 5    &   .��5!   *   u� 
 u� Brush

 �   �6:   >� 5"   *    >� Brush
 �  ��6;   5#   '    � Geometry 5%   "   k� 5&   &   -   5        mesh��5&   5   5(      5)      5+      5-      ]� 5.   
   $��False��6   .+�5/      c� $	��Top=�6   
������ .@�50      �� -   5        $��Load Heightfield...��50      67   �� 51      -   5        $��Load Texture...��51      63   �� 52      -   5        $��Restart��52      6+   53      �� 54      $	��Top=�6   $f��`Load a tile and a matching texture. Use mouse with left button down to rotate. Use W key to fly.��6-   �� 55      $��Bottom=�6   
������ .@�56      �� $��Speed: ��6   �� 57      -   5        $��Speed��57      $��(speed)��6)   �� 58      $��
Altitude: ��6   �� 59      -	   5        $��Altitude��59      $��
(altitude)��6,   �� 5:      $��Longitude: ��6   �� 5;      -
   5        $��	Longitude��5;      $��(longitude)��6-   �� 5<      $��
Latitude: ��6   �� 5=      -   5        $��Latitude��5=      $��
(latitude)��6,   �� 5>      $��Framerate: ��6   �� 5?      -   5        $��	Framerate��5?      $��(framerate)��6-   5@      5A      5B      5C      