   M S B A M L   `   `   `  ����H  DAppHockeyClub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AppHockeyClub.listpageAppHockeyClub.listpage  5   	   '    !AppHockeyClub.listpage.PlayWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:AppHockeyClub.listpage     5   	     � Title$!  Расписание игр��5   	   $	��450��6    $	��900��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5         ActionButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value  ColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  DataGridStyle&   System.Windows.Controls.DataGrid��%�  &	        &	 e    &	 |    7  �� 5   
   " ��6*   .�5      ��  � ��
 ���� 6+   �� 5       � �� �	#FF3E3E406,   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 10q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 4��5   !   # z��5   !   ._�5      �� #��z��6/   #��z��5    -   5!      5"      5$      	 5%      P� 5&      
 �@J�IsMouseOver$
 True��61   . �5'      ��  � �� �	#FF3E3E4063   �� 5(       � �� �	#FF007ACC64   5)      P� 5*      
 � ��$
 True��6/   . �5+      ��  � �� �	#FF007ACC63   �� 5,       � �� �	#FF007ACC64   5-      5/      �� 52   
   "  6*   .�53      ��  � �� �	#FF2D2D306+   �� 54       � ��
 �����6+   �� 55       � ��$
 Bold"�6+   �� 56       � ��$ 0,0,0,1q�60   �� 57       � �� �	#FF3E3E406,   �� 58       � ��$
 10,5q�6(   59      �� 5<   
   "  6&   .�5=      ��  � �� �	#FF2525266+   �� 5>       � ��
 �����6+   �� 5?       � �� �	#FF3E3E406,   �� 5@       � ��$ 1q�60   �� 5A       �@ RowBackground �	#FF2525266.   �� 5B        �@ AlternatingRowBackground �	#FF2D2D3069   �� 5C       �@ GridLinesVisibility$
 None=�64   �� 5D       �@ HeadersVisibility$ Column=�62   �� 5E       � ��$
 True��6>   �� 5F       �@��PanningMode$
 Both=�69   �� 5G       �@��IsFlicksEnabled$ False��67   �� 5H       �@ ColumnHeaderStyle8   62   �� 5I       �@ SelectionMode$ Single=�6.   �� 5J       �@ SelectionUnit$ FullRow=�6.   �� 5K       �@ CanUserAddRows$ False��6/   5L      5M      .��5O      � ���	#FF252526 � RowDefinitions 5P   
   �� 5Q      $
��Auto �6   �� 5R      $��* �6   �� 5S      $
��Auto �6   .+�5W   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   $
��Left=�6G   $��Center=�6b   .+�5X      �� -   5        $��← Назад��5X      #��[  5Y      $��0,0,20,0q�5[      �� 5\      $!��Расписание игр��6   
�������$��18(�5^      $
��Bold"�5_      5`        5c   
   -   5          Name$ GamesScheduleDataGrid��5c      $��1��5d      $��
10,0,10,10q�5e      #��[ 5f         AutoGenerateColumns$ False��5g         Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Header$ ID расписания��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5k   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5j   %   �� *GameScheduleId+5k   %     5l      $ Команда��6%   $
 Auto 5n   %    5m   %   �� *
TeamName+5n   %     5o      $ 
Арена��6%   $
 Auto 5q   %    5p   %   �� *	ArenaName+5q   %     5r      $ Дата игры��6%   $ * 5t   %    5s   %   �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��5t   %     5u      $ Начало игры��6%   $ * 5w   %    5v   %   �� *	TimeStart+5w   %     5x      $! Окончание игры��6%   $ * 5z   %    5y   %   �� *	TimeEnd+5z   %   5|      5�      5�      