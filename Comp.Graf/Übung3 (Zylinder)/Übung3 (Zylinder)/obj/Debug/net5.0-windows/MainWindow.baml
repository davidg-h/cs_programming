   M S B A M L   `   `   `  ����  Übung3 (Zylinder)    Cylinder.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  
MainWindow��5      $	��400��6   $	��400��6"   .��5      � .+�5   
   '�  '� Camera 5      =� 5       � Position$ 0,-2,41�6$    � LookDirection$ 0,0.5,-15�66    �� 	Transform 5	      Y� 5
      .�5      ��  �� Rotation 5   "   �� 5   &    �� Axis$ 1,0,05�6:    �� Angle 5   :   ��  �� ElementName$ 	rotSlider��	 �� Path$	 Value�5      5      5      .x�5      3  -System.Windows.Media.Media3D.ModelUIElement3D  
   Model
 5      h� 5      .��5      �� � 5      -   5        bottomModel�� � Material 5      u� 5   "    u� Brush
 �����62    � BackMaterial 5      u� 5   "   
 � ���62    � Geometry 5       k� 5!   "    k� 	Positions �    k� TriangleIndices �     5#   %   5%      � 5&      -   5        topModel�� 5'      u� 5(   "   
 � � �62    5*      u� 5+   "   
 �   �62    5-      k� 5.   "    �    �     50   %   52      � 53      -   5        body�� 54      u� 55   "   
 �  ��62    57      u� 58   "   
 ��  �62    5:      k� 5;   "    �    �     5=   %   5?      � 5@      -   5        hat�� 5A      u� 5B   "   
 ��  �62   5D      5E      5G      5H      �� 5I   
   -   5         ��Name$ 	rotSlider��5I      $��Right=�6$    �� Orientation$ Vertical=�6@    � Minimum$
 -180Q�5J       � Maximum$	 180Q�6     � Value$ 0Q�6.   5K      5L      