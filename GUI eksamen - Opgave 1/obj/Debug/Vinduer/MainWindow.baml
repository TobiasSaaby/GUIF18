   M S B A M L   `   `   `  ����Q  MGUI eksamen - Opgave 1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:GUI_eksamen___Opgave_1GUI_eksamen___Opgave_1  5   	   '    !GUI_eksamen___Opgave_1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6local$clr-namespace:GUI_eksamen___Opgave_1     5   	   $	��400��5   	   $	��800��6     � Title  5   	   ��  �� Path$ Title� � 	Resources 5         BackgroundBrush �� Color  ForegroundBrush/  )GUI_eksamen___Opgave_1.IdColourConvertion  IdToColorConverter �� 
TargetType �� Property �� Value  BottonToolbarStyle �� Triggers P� Property	 P� Value3  -System.Windows.Media.Effects.DropShadowEffect
   ShadowDepth  BistadTemplate �� Padding �� 	Converter��%�  &	        &	       &	 >     '�� Q     7  &	 *    &	 �    7  �� 5   
   $ Bisque��62   �� 5	   
   $
 Blue��62     5
   
   6#   �� 5   
   " ��6   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��8   6+   �� 5       � ��$	 Top=�62   �� 5       � ��$
 Left=�64   �� 5       � ��$ 92��6&   5      �� 5   
   " ��6+   �5      �� 5       � ��$ 32��6*   �� 5       � ��
 ��  �6/   �� 5       � ��$ 	ExtraBold"�6/   �� 5       � ��$ 18(�6-   �� 5       � ��$ Arial)�6/    5      P� 5       �@J�IsMouseOver	 . . �5       ��  �@J�Effect 5!        5"      $
 2Q�6/   5$      5%      5'      �� 5(   
   .R�5)      � .+�5*      �� $
 5, 0q�6B   $��50��5+      ��5*      �� $ Bistaderne.Name���5,      �� $ Bistaderne.Name�8   5/      50      51       � DataContext 53      $  GUI_eksamen___Opgave_1.AltIAlt  54   
   -   5        altialt��54      .��57      ]� -   5        $��dockPanelMain��57      .+�58   
   o� -   5        $��mainMenu��58   $   $	��Top=�6   .@�59      m� $��_File��6   .@�5:      m� $
��_New��6    m� Command 6)   �� *NewFileCommand+m� 5;      $��_Open��6    6*   �� *OpenFileCommand+m� 5<      $��_Save��6    6*   �� *SaveCommand+m� 5=      $��Save _As��6    6-   �� *SaveAsCommand+m� 5>      $��E_xit��6    6*   �� *CloseAppCommand+5?      m� 5@      $��	_Bistader��6   .@�5A      m� $��	_Previous��6    6.   �� *Bistaderne.PreviusCommand+m� 5B      $��_Next��6    6*   �� *Bistaderne.NextCommand+m� 5C      $��_Add new��6    6-   �� *Bistaderne.AddCommand+m� 5D      $��_Edit��6    6*   �� *Bistaderne.EditCommand+m� 5E      $��_Delete��6    6,   �� *Bistaderne.DeleteCommand+5F      m� 5G      $��_Miderapporter��6   .@�5H      m� $��	_Previous��6    6.   �� *Miderne.PreviusCommand+m� 5I      $��_Next��6    6*   �� *Miderne.NextCommand+m� 5J      $��_Add new��6    6-   �� *Miderne.AddCommand+m� 5K      $��_Edit��6    6*   �� *Miderne.EditCommand+m� 5L      $��_Delete��6    6,   �� *Miderne.DeleteCommand+5M      m� 5N      $��_Stil��6   .@�5O      m� $��_Default��6    m� CommandParameter$ Default��6Y    6-   �� *Bistaderne.ColorCommand+6Y   m� 5P      $��_Bisque��6   $ Bisque��6X    6,   �� *Bistaderne.ColorCommand+6X   m� 5Q      $��Light_Green��6   $ 
LightGreen��6\    60   �� *Bistaderne.ColorCommand+6\   m� 5R      $��
_LightBlue��6   $ 	LightBlue��6[    6/   �� *Bistaderne.ColorCommand+6[   m� 5S      $��Ghost_White��6   $ 
GhostWhite��6\    60   �� *Bistaderne.ColorCommand+6\   5T      5U      c� 5V   
   $	��Top=�6   $
��auto��6'   $��20(�5W      $
��Bold"�6    
�������.@�5Z      ��  � ToolTip$ gå til forrige bistad��6   #��[ 5\      ��5[      �� *Bistaderne.PreviusCommand+.��5]      �� $��../Images/previous.png��6   $��Uniform=�68   5^      �� 5_      $ Gå til naeste bistad��6   #��[ 5a      ��5`      �� *Bistaderne.NextCommand+.��5b      �� $��../Images/next.png��6   $��Uniform=�64   5c      �� 5e      $ Tilfoj ny bistad��6   #��[ 5g      ��5f      �� *Bistaderne.AddCommand+.��5h      �� $��../Images/add.png��6   $��Uniform=�63   5i      �� 5j      $ Slet valgte bistad��6   #��[ 5l      ��5k      �� *Bistaderne.DeleteCommand+.��5m      �� $��../Images/remove.png��6   $��Uniform=�66   5n      �� 5p      $
��auto��6   $	��5,0q�6%   �� 5q      -   5        $ Vis alle rapporter��5q      #��[ 62   .��5r      �� $��../Images/show.png��6   $��Uniform=�64   5t      5v      �� 5w   
   $��Bottom=�6   $��Bottom=�6,   
�������.@�5x      �� $��Bistad antal:��6   �� 5y      -   5        $��sbiBistadAntal��5y      $��40��62   ��5z      �� $ Bistaderne.Count��� 5{      -   5        $��sbiDateTime��5{      $��Right=�6/   .��5|      �� -   5        $��spClock��5|   6    �� Orientation$ 
Horizontal=�6   .+�5}      �� -   5        $��tblkDate��5}   -   $	��4,0q�6    ��6=   �� $ Bistaderne.Date��� 5~      -	   5        $��tblkTime��5~   -   $	��4,0q�6    ��6=   �� $ Bistaderne.Time�5      5�      5�      � 5�   
   -
   5        $��
BistadGrid��5�      #���   6!    � ColumnDefinitions 5�      �� 5�      $
��115* �6#   62   �� 5�      $
��111* �6#   �� 5�      $��5 �6#   6/   �� 5�      $
��563* �6#   62   .+�5�      �� -   5        $��label1��5�   2   $��28��6   $��10,9,0,0q�6    $	��Top=�6@   $
��Left=�6X   $��57��6s   .��6�   	Bikube:6�   �� 5�      -   5        $��tbxName��5�      $��
72,10,10,0q�5�        
JamesStyle#��[ 5�      $��2��6:   ��5�      �� $ Bistaderne.Name�5�   :   &   System.Windows.Controls.DataGrid  5�      -   5        $��dgridBistad��5�         AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�5�      $��10,42,10,10q�5�         CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    MinRowHeight$ 12Q�5�      $��2��5�   N   ��5�      �� *
Bistaderne+ �� SelectedIndex 5�      �� $ Bistaderne.CurrentIndex� �� SelectedItem 5�      �� $ CurrentBistad�   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Navn��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+ 5�      )  #System.Windows.Controls.DataGridRow��%E   '        �� 5�      "  6   .�5�      -   5        5�      5�      5�      �� 5�      $��2��6   $��Center=�5�      $��Stretch=�5�      $��4��5�      $��0.4,0q�6%     5�      -   5        $��dgridBistader��5�       .  $
 TrueY�5�      $��3��5�      $��8.6,9q�5�       .   .   . $ 12Q�5�      ��5�      �� *	Miderne+ 5�      �� $ Miderne.CurrentIndex� 5�      �� $ Miderne.CurrentMider� 5�        5�      $ 	Tilhører��6%    67   �� *Tilhorer.Name+  5�      $
 Dato��6)    67   �� *Dato+  5�      $ Antal��6)    68   �� *Antal+  5�      $ 	Kommentar��6)    6<   �� *	Kommentar+5�      5�      5�      5�      