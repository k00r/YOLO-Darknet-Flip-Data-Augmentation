# YOLO-Darknet-Flip-Data-Augmentation
a C# .NET code that rotates images around the Y axis and adjusts bounding box coordinates accordingly,if you can't use Darknet's built-in flip data augmentation during training(flip=0 in cfg) because not all your classes are vertically symmetrical,especially useful with some letters and numbers

Only supports jpg files and YOLO annotation format at the moment

REPLACES YOUR ORIGINAL FILES!

adds an "f" letter at the end of the file names so your augmented samples can be placed in the same folder with your original ones
