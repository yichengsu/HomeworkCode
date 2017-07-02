% imread() : Read image from graphics file.
I = imread('image.bmp');
% figure : Creates a new figure window, and returns its handle.
figure;
% imshow() : Displays the grayscale image.
subplot(121);imshow(I);title('image.bmp');
% imhist() : Display histogram of image data.
subplot(122);imhist(I);title('Histogram');


% histeq() : Enhance contrast using histogram equalization.
J = histeq(I);
figure;
subplot(121);imshow(J);title('Histogram Equalization');
subplot(122);imhist(J);title('Histogram');


% using "Median filtering" because of the "salt-and-pepper noise".
% medfilt2() : Perform 2-D median filtering.
K = medfilt2(J);
% my "Median filtering"
% convert the picture to double.
pic_double = im2double(J);
% mask is 3
m = 3;
% get the size fo the picture
[x,y] = size(pic_double);
% create a new picture to store the result
pic_new = zeros(x-m+1, y-m+1);
% foreach every pixel,find the median in every mask
for i=1:x-m+1
    for j=1:y-m+1
            temp = pic_double(i:i+m-1,j:j+m-1);
            pic_new(i,j) = median(temp(:));
    end;
end;
figure;
subplot(121);imshow(K);title('Median filtering');
subplot(122);imshow(pic_new);title('My Median filtering');


% graythresh() : Compute global image threshold using Otsu's method.
thresh = graythresh(K);
% BW = IM2BW(I,LEVEL) converts the intensity image I to black and white.
K1 = im2bw(K,thresh);
% my Binarization image
K2 = zeros(x,y);
for i=1:x
    for j=1:y
        if (K(i,j)>200 || K(i,j)<50)
            K2(i,j) = 255;
        end;
    end;
end;
K2 = K2 .* double(K);
figure;
subplot(121);imshow(K1);title('Binarization image');
subplot(122);imshow(K2);title('My Binarization image');

% strel() : Create morphological structuring element.
% SE = STREL('disk',R,N) creates a flat disk-shaped structuring element
%   with the specified radius, R.  R must be a nonnegative integer.  N must
%   be 0, 4, 6, or 8.
se = strel('disk',3);
% IM2 = IMDILATE(IM,SE) dilates the grayscale, binary, or packed binary
%    image IM, returning the dilated image, IM2.  SE is a structuring element
%    object, or array of structuring element objects, returned by the STREL
%    function.
E = imdilate(K2,se);
figure;imshow(E);title('dilation');


% IM2 = IMERODE(IM,SE) erodes the grayscale, binary, or packed binary image
%    IM, returning the eroded image, IM2.  SE is a structuring element
%    object, or array of structuring element objects, returned by the
%    STREL function.
E2 = imerode(E,se);
figure;imshow(E2);title('erosion');