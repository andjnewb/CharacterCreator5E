   M S B A M L   `   `   `  ����T  PGroupProject5ECharCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GroupProject5ECharCreatorGroupProject5ECharCreator  5   	   �Gclr-namespace:GroupProject5ECharCreator._5EDatabaseDataSetTableAdapters9GroupProject5ECharCreator._5EDatabaseDataSetTableAdapters  5   	   2    ,GroupProject5ECharCreator.NewCharacterWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:GroupProject5ECharCreator     5   	   s_5EDatabaseDataSetTableAdaptersGclr-namespace:GroupProject5ECharCreator._5EDatabaseDataSetTableAdapters     5   	   -   5          � Title$  NewCharacterWindow��5	   	   $	��450��6$   $	��800��61    � 	Resources 5
      2   ,GroupProject5ECharCreator._5EDatabaseDataSet   _5EDatabaseDataSet  classesViewSource �� Source �� Source  racesViewSource3   -GroupProject5ECharCreator._5EDatabaseDataSet1  _5EDatabaseDataSet1  classesViewSource1  racesViewSource1��%"  &	        &	      7   &	 @     7   &	 k     &	 ~     7  &	 �     7    5   
   6#   �� 5   
    69   �� *	Classes+8   �� 5   
    67   �� *Races+8     5   
   6$   �� 5   
    6:   �� *	Classes+8   �� 5   
    68   �� *Races+8   5      .��5      �  � DataContext# [ 6   .+�5   
   � -   5         �Name$ grid1��5      # [ 6   $
��Left=�6M   $��	85,96,0,0q�6h   $	��Top=�6{    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    5      � 5   
   -   5        $ grid2��5      # [ 6   $
��Left=�6P   $��	24,64,0,0q�6k   $	��Top=�6~    5       �� 5!      $
��Auto �6#   �� 5"      $
��Auto �6#    5$      �� 5%      $
��Auto �6    .+�5'      �� $��Class:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��0��6[   $��Center=�6h   �� 5(      -   5         ��Name$ classComboBox��5(      $��1��6.   	 �� DisplayMemberPath$	 Class��6>   $
��Left=�6X   $
��Auto��6s   $��3q�6�   $��0��6�   $��Center=�6�   $	��120��6�   ��6�   �� ��5)      �� 5*      .R�5+      $� 5,      5.      5/      � 50   
   -   5        $ grid3��50      # [ 6   $
��Left=�6N   $��
25,110,0,0q�6i   $	��Top=�6}    51      �� 52      $
��Auto �6#   �� 53      $
��Auto �6#    55      �� 56      $
��Auto �6    58      � 59   
   -   5        $ grid4��59      # [ 6   $
��Left=�6N   $��
25,110,0,0q�6i   $	��Top=�6}    5:      �� 5;      $
��Auto �6#   �� 5<      $
��Auto �6#    5>      �� 5?      $
��Auto �6    .+�5A      �� $��Race:��6   $��0��6$   $
��Left=�64   $��3q�6O   $��0��6Z   $��Center=�6g   �� 5B      -   5        $ raceComboBox��5B      $��1��6-   $
	 Race��6=   $
��Left=�6V   $
��Auto��6q   $��3q�6�   $��0��6�   $��Center=�6�   $	��120��6�   ��6   �� ��5C      �� 5D      .R�5E      $� 5F      5H      5I      5J      5K      