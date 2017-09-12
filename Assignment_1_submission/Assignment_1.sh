#set -o nounset
mcs Part_1/*.cs
mv Part_1/Data.exe .
# 1 (C)
echo "1 (C)"
printf "The error for the training data is:"
mono Data.exe updated_train.txt updated_train.txt

# 1 (D)
echo "1 (D)"
printf "The error the Test data is:"
mono Data.exe updated_train.txt updated_test.txt

# 1 (E)
echo "1 (E)"
mono Data.exe updated_train.txt 

# 2 (A)
mcs Part_2/*.cs
mv Part_2/Data.exe .
echo "2 (A)"
printf "Depth set to 1: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 1
echo
printf "Depth set to 2: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 2
echo
printf "Depth set to 3: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 3
echo
printf "Depth set to 4: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 4
echo
printf "Depth set to 5: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 5
echo
printf "Depth set to 10: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 10
echo
printf "Depth set to 15: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 15
echo
printf "Depth set to 20: "
mono Data.exe updated_training00.txt updated_training01.txt updated_training02.txt updated_training03.txt 20

# 2 (B)
echo
echo "2 (B)"
printf "Accuracy on Test Data: "
mono Data.exe updated_train.txt updated_test.txt 5

exit 0
