   M S B A M L   `   `   `  ����H  DAppHockeyClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AppHockeyClub.listpageAppHockeyClub.listpage  5   	   (    "AppHockeyClub.listpage.TeamsWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:AppHockeyClub.listpage     5   	     � Title$  Команды��5   	   $	��450��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         ActionButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value  ColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  DataGridStyle&   System.Windows.Controls.DataGrid��%�  &	        &	 e    &	 |    7  �� 5   
   " ��6*   .�5      ��  � ��
 ���� 6+   �� 5       � �� �	#FF3E3E406,   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 10q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 4��5   !   # z��5   !   ._�5      �� #��z��6/   #��z��5   -   5      5       5"      	 5#      P� 5$      
 �@J�IsMouseOver$
 True��61   . �5%      ��  � �� �	#FF3E3E4063   �� 5&       � �� �	#FF007ACC64   5'      P� 5(      
 � ��$
 True��6/   . �5)      ��  � �� �	#FF007ACC63   �� 5*       � �� �	#FF007ACC64   5+      5-      �� 50   
   "  6*   .�51      ��  � �� �	#FF2D2D306+   �� 52       � ��
 �����6+   �� 53       � ��$
 Bold"�6+   �� 54       � ��$ 0,0,0,1q�60   �� 55       � �� �	#FF3E3E406,   �� 56       � ��$
 10,5q�6(   57      �� 5:   
   "  6&   .�5;      ��  � �� �	#FF2525266+   �� 5<       � ��
 �����6+   �� 5=       � �� �	#FF3E3E406,   �� 5>       � ��$ 1q�60   �� 5?       �@ RowBackground �	#FF2525266.   �� 5@        �@ AlternatingRowBackground �	#FF2D2D3069   �� 5A       �@ GridLinesVisibility$
 None=�64   �� 5B       �@ HeadersVisibility$ Column=�62   �� 5C       � ��$
 True��6>   �� 5D       �@��PanningMode$
 Both=�69   �� 5E       �@��IsFlicksEnabled$ False��67   �� 5F       �@ ColumnHeaderStyle8   62   �� 5G       �@ SelectionMode$ Single=�6.   �� 5H       �@ SelectionUnit$ FullRow=�6.   �� 5I       �@ CanUserAddRows$ False��6/   5J      5K      .��5M      � ���	#FF252526 � RowDefinitions 5N   
   �� 5O      $
��Auto �6   �� 5P      $��* �6   �� 5Q      $
��Auto �6   .+�5U   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   $
��Left=�6G   $��Center=�6b   .+�5V      �� -   5        $��← Назад��5V      #��[  5W      $��0,0,20,0q�5Y      �� 5Z      $��Список команд��6   
�������$��18(�5\      $
��Bold"�5]      5^        5a   
   -   5          Name$ TeamsDataGrid��5a      $��1��5b      $��
10,0,10,10q�5c      #��[ 5d         AutoGenerateColumns$ False��5e         Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5i      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5h      �� *TeamId+5i        5j      $ Название��6%   $ * 5l       5k      �� *Name+5l        5m      $ Тренер��6%   $
 Auto 5o       5n      �� *	CoachName+5o        5p      $  Кол-во игроков��6%   $
 Auto 5r       5q      �� *QuantityPlayers+5r        5s      $' !График тренировок��6%   $
 Auto 5u       5t      �� *TrainingScheduleId+5u        5v      $ Игры��6%   $
 Auto 5x       5w      �� *GameScheduleId+5x      5z      �� 5}   
   $��2��6   $ 
Horizontal=�5~      $��Right=�5      $��10q�5�      .+�5�      �� -   5        $��Добавить��5�      #��[  5�      5�      �� 5�      -   5        $ ��Редактировать��5�      #��[  5�      5�      �� 5�      -   5        $��Удалить��5�      #��[  5�      5�      5�      5�      5�      