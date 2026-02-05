// File size formatter
function formatFileSize(bytes) {
    if (bytes < 1024) return bytes + ' B';
    if (bytes < 1024 * 1024) return (bytes / 1024).toFixed(2) + ' KB';
    return (bytes / (1024 * 1024)).toFixed(2) + ' MB';
}

document.addEventListener('DOMContentLoaded', () => {
    console.log('Venue registration script loaded');
    
    let updateProgress;
    let uploadedPhotos = [];

    // Get all DOM elements
    const businessLicenseInput = document.getElementById('businessLicenseInput');
    const businessLicenseUpload = document.getElementById('businessLicenseUpload');
    const businessLicensePreview = document.getElementById('businessLicensePreview');
    const businessLicenseRemove = document.getElementById('businessLicenseRemove');

    const landCertificateInput = document.getElementById('landCertificateInput');
    const landCertificateUpload = document.getElementById('landCertificateUpload');
    const landCertificatePreview = document.getElementById('landCertificatePreview');
    const landCertificateRemove = document.getElementById('landCertificateRemove');

    const photoGalleryInput = document.getElementById('photoGalleryInput');
    const photoUploadTrigger = document.getElementById('photoUploadTrigger');
    const photoGalleryContainer = document.getElementById('photoGalleryContainer');

    // Business License Upload
    if (businessLicenseUpload) {
        businessLicenseUpload.addEventListener('click', () => {
            console.log('Business license upload clicked');
            businessLicenseInput.click();
        });
    }

    if (businessLicenseInput) {
        businessLicenseInput.addEventListener('change', (e) => {
            console.log('Business license file selected');
            const file = e.target.files[0];
            if (file) {
                if (file.size > 10 * 1024 * 1024) {
                    alert('File size must be less than 10MB');
                    return;
                }
                
                document.getElementById('businessLicenseFileName').textContent = file.name;
                document.getElementById('businessLicenseFileSize').textContent = formatFileSize(file.size);
                
                // Show image preview if it's an image file
                if (file.type.startsWith('image/')) {
                    const reader = new FileReader();
                    reader.onload = (e) => {
                        const previewImg = document.getElementById('businessLicensePreviewImg');
                        if (previewImg) {
                            previewImg.src = e.target.result;
                            previewImg.classList.remove('hidden');
                        }
                    };
                    reader.readAsDataURL(file);
                }
                
                businessLicenseUpload.classList.add('hidden');
                businessLicensePreview.classList.remove('hidden');
                
                if (updateProgress) updateProgress();
            }
        });
    }

    if (businessLicenseRemove) {
        businessLicenseRemove.addEventListener('click', () => {
            console.log('Remove business license');
            businessLicenseInput.value = '';
            const previewImg = document.getElementById('businessLicensePreviewImg');
            if (previewImg) {
                previewImg.src = '';
                previewImg.classList.add('hidden');
            }
            businessLicenseUpload.classList.remove('hidden');
            businessLicensePreview.classList.add('hidden');
            
            if (updateProgress) updateProgress();
        });
    }

    // Land Certificate Upload
    if (landCertificateUpload) {
        landCertificateUpload.addEventListener('click', () => {
            console.log('Land certificate upload clicked');
            landCertificateInput.click();
        });
    }

    if (landCertificateInput) {
        landCertificateInput.addEventListener('change', (e) => {
            console.log('Land certificate file selected');
            const file = e.target.files[0];
            if (file) {
                if (file.size > 10 * 1024 * 1024) {
                    alert('File size must be less than 10MB');
                    return;
                }
                
                document.getElementById('landCertificateFileName').textContent = file.name;
                document.getElementById('landCertificateFileSize').textContent = formatFileSize(file.size);
                
                // Show image preview if it's an image file
                if (file.type.startsWith('image/')) {
                    const reader = new FileReader();
                    reader.onload = (e) => {
                        const previewImg = document.getElementById('landCertificatePreviewImg');
                        if (previewImg) {
                            previewImg.src = e.target.result;
                            previewImg.classList.remove('hidden');
                        }
                    };
                    reader.readAsDataURL(file);
                }
                
                landCertificateUpload.classList.add('hidden');
                landCertificatePreview.classList.remove('hidden');
                
                if (updateProgress) updateProgress();
            }
        });
    }

    if (landCertificateRemove) {
        landCertificateRemove.addEventListener('click', () => {
            console.log('Remove land certificate');
            landCertificateInput.value = '';
            const previewImg = document.getElementById('landCertificatePreviewImg');
            if (previewImg) {
                previewImg.src = '';
                previewImg.classList.add('hidden');
            }
            landCertificateUpload.classList.remove('hidden');
            landCertificatePreview.classList.add('hidden');
            
            if (updateProgress) updateProgress();
        });
    }

    // Photo Gallery Upload
    if (photoUploadTrigger) {
        photoUploadTrigger.addEventListener('click', () => {
            console.log('Photo upload clicked');
            photoGalleryInput.click();
        });
    }

    if (photoGalleryInput) {
        photoGalleryInput.addEventListener('change', (e) => {
            console.log('Photos selected:', e.target.files.length);
            const files = Array.from(e.target.files);
            
            if (uploadedPhotos.length + files.length > 10) {
                alert('Maximum 10 photos allowed');
                return;
            }

            files.forEach(file => {
                if (file.size > 10 * 1024 * 1024) {
                    alert(`${file.name} is too large. Maximum 10MB per photo.`);
                    return;
                }

                const reader = new FileReader();
                reader.onload = (e) => {
                    const photoId = Date.now() + Math.random();
                    uploadedPhotos.push({ id: photoId, file: file, dataUrl: e.target.result });

                    const photoDiv = document.createElement('div');
                    photoDiv.className = 'aspect-square rounded-2xl bg-cover bg-center relative group';
                    photoDiv.style.backgroundImage = `url('${e.target.result}')`;
                    photoDiv.dataset.photoId = photoId;

                    const removeBtn = document.createElement('button');
                    removeBtn.type = 'button';
                    removeBtn.className = 'absolute -top-2 -right-2 size-8 bg-red-500 text-white rounded-full flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity shadow-lg';
                    removeBtn.innerHTML = '<span class="material-symbols-outlined text-sm">close</span>';
                    removeBtn.onclick = () => removePhoto(photoId);

                    photoDiv.appendChild(removeBtn);
                    photoGalleryContainer.insertBefore(photoDiv, photoUploadTrigger);
                    
                    if (updateProgress) updateProgress();
                };
                reader.readAsDataURL(file);
            });

            photoGalleryInput.value = '';
        });
    }

    function removePhoto(photoId) {
        console.log('Remove photo:', photoId);
        uploadedPhotos = uploadedPhotos.filter(p => p.id !== photoId);
        const photoDiv = photoGalleryContainer.querySelector(`[data-photo-id="${photoId}"]`);
        if (photoDiv) photoDiv.remove();
        
        if (updateProgress) updateProgress();
    }

    // Save Progress functionality
    const saveProgressBtn = Array.from(document.querySelectorAll('button')).find(btn => btn.textContent.includes('Save Progress'));
    
    console.log('Save Progress button found:', saveProgressBtn ? 'YES' : 'NO');
    
    if (saveProgressBtn) {
        saveProgressBtn.addEventListener('click', () => {
            console.log('Save Progress clicked');
            
            const formData = {
                venueName: document.querySelector('input[placeholder*="Smash City Arena"]')?.value,
                sportTypes: Array.from(document.querySelectorAll('input[name="SportTypes"]:checked')).map(cb => cb.value),
                address: document.querySelector('input[placeholder*="physical location"]')?.value,
                businessLicense: businessLicenseInput?.files[0]?.name,
                landCertificate: landCertificateInput?.files[0]?.name,
                photoCount: uploadedPhotos.length
            };

            localStorage.setItem('venueRegistrationDraft', JSON.stringify({
                ...formData,
                savedAt: new Date().toISOString()
            }));

            const btn = saveProgressBtn;
            const originalHTML = btn.innerHTML;
            btn.innerHTML = '<span class="material-symbols-outlined text-base mr-2">check_circle</span> <span>Saved!</span>';
            btn.style.backgroundColor = '#22c55e';
            btn.style.color = 'white';
            
            setTimeout(() => {
                btn.innerHTML = originalHTML;
                btn.style.backgroundColor = '';
                btn.style.color = '';
            }, 2000);

            console.log('Draft saved:', formData);
        });
    }

    // Progress Tracking System
    updateProgress = function() {
        const venueName = document.querySelector('input[placeholder*="Smash City Arena"]')?.value;
        const sportTypes = document.querySelectorAll('input[name="SportTypes"]:checked').length;
        const address = document.querySelector('input[placeholder*="physical location"]')?.value;
        const hasBusinessLicense = businessLicenseInput?.files?.length > 0;
        const hasLandCertificate = landCertificateInput?.files?.length > 0;
        const amenities = document.querySelectorAll('.grid input[type="checkbox"]:checked').length;
        const photos = uploadedPhotos.length;

        // Calculate completion
        let completedSteps = 0;
        let totalSteps = 7;

        if (venueName && venueName.trim().length > 0) completedSteps++;
        if (sportTypes > 0) completedSteps++;
        if (address && address.trim().length > 0) completedSteps++;
        if (hasBusinessLicense) completedSteps++;
        if (hasLandCertificate) completedSteps++;
        if (amenities > 0) completedSteps++;
        if (photos > 0) completedSteps++;

        const percentage = Math.round((completedSteps / totalSteps) * 100);

        // Update progress bar
        const progressBar = document.querySelector('.bg-primary.rounded-full');
        const progressText = document.querySelector('.text-primary.text-sm.font-black');
        
        if (progressBar) {
            progressBar.style.width = `${percentage}%`;
        }
        
        if (progressText) {
            progressText.textContent = `${percentage}%`;
        }

        // Update step indicators
        const stepItems = document.querySelectorAll('aside ul li');
        if (stepItems.length >= 4) {
            // Account Created (always done)
            stepItems[0].classList.remove('opacity-50');
            const icon0 = stepItems[0].querySelector('.material-symbols-outlined');
            if (icon0) {
                icon0.className = 'material-symbols-outlined text-primary text-xl';
                icon0.textContent = 'check_circle';
            }

            // Venue Identity
            if (venueName && sportTypes > 0 && address) {
                stepItems[1].classList.remove('opacity-50');
                const icon1 = stepItems[1].querySelector('.material-symbols-outlined');
                const text1 = stepItems[1].querySelector('span.text-sm');
                if (icon1) {
                    icon1.className = 'material-symbols-outlined text-primary text-xl';
                    icon1.textContent = 'check_circle';
                }
                if (text1) {
                    text1.classList.remove('text-slate-700', 'dark:text-slate-300');
                    text1.classList.add('text-slate-900', 'dark:text-white');
                }
            } else {
                stepItems[1].classList.add('opacity-50');
                const icon1 = stepItems[1].querySelector('.material-symbols-outlined');
                if (icon1) {
                    icon1.className = 'material-symbols-outlined text-primary text-xl';
                    icon1.textContent = 'radio_button_checked';
                }
            }

            // Document Upload
            if (hasBusinessLicense && hasLandCertificate) {
                stepItems[2].classList.remove('opacity-50');
                const icon2 = stepItems[2].querySelector('.material-symbols-outlined');
                const text2 = stepItems[2].querySelector('span.text-sm');
                if (icon2) {
                    icon2.className = 'material-symbols-outlined text-primary text-xl';
                    icon2.textContent = 'check_circle';
                }
                if (text2) {
                    text2.classList.remove('text-slate-500');
                    text2.classList.add('text-slate-700', 'dark:text-slate-300');
                }
            } else {
                stepItems[2].classList.add('opacity-50');
                const icon2 = stepItems[2].querySelector('.material-symbols-outlined');
                if (icon2) {
                    icon2.className = 'material-symbols-outlined text-slate-300 text-xl';
                    icon2.textContent = 'radio_button_unchecked';
                }
            }

            // Expert Verification (always pending)
            stepItems[3].classList.add('opacity-50');
        }

        // Enable/disable submit button
        const submitBtn = Array.from(document.querySelectorAll('button')).find(btn => btn.textContent.includes('Submit for Approval'));
        
        const isValid = venueName && venueName.trim().length > 0 && 
                       sportTypes > 0 && 
                       address && address.trim().length > 0 && 
                       hasBusinessLicense && 
                       hasLandCertificate;
        
        if (submitBtn) {
            if (isValid) {
                submitBtn.disabled = false;
                submitBtn.classList.remove('opacity-50', 'cursor-not-allowed');
                submitBtn.title = 'Click to submit for approval';
            } else {
                submitBtn.disabled = true;
                submitBtn.classList.add('opacity-50', 'cursor-not-allowed');
                
                let missing = [];
                if (!venueName || venueName.trim().length === 0) missing.push('Venue Name');
                if (sportTypes === 0) missing.push('Sport Types');
                if (!address || address.trim().length === 0) missing.push('Address');
                if (!hasBusinessLicense) missing.push('Business License');
                if (!hasLandCertificate) missing.push('Land Certificate');
                
                submitBtn.title = `Required: ${missing.join(', ')}`;
            }
        }

        console.log(`Progress: ${percentage}%, Valid: ${isValid}`);
        return { percentage, isValid };
    };

    // Business License handlers
    if (businessLicenseInput) {
        businessLicenseInput.addEventListener('change', (e) => {
            const file = e.target.files[0];
            if (file) {
                if (file.size > 10 * 1024 * 1024) {
                    alert('File size must be less than 10MB');
                    return;
                }
                
                document.getElementById('businessLicenseFileName').textContent = file.name;
                document.getElementById('businessLicenseFileSize').textContent = formatFileSize(file.size);
                
                if (file.type.startsWith('image/')) {
                    const reader = new FileReader();
                    reader.onload = (e) => {
                        const previewImg = document.getElementById('businessLicensePreviewImg');
                        if (previewImg) {
                            previewImg.src = e.target.result;
                            previewImg.classList.remove('hidden');
                        }
                    };
                    reader.readAsDataURL(file);
                }
                
                businessLicenseUpload.classList.add('hidden');
                businessLicensePreview.classList.remove('hidden');
                
                if (updateProgress) updateProgress();
            }
        });
    }

    if (businessLicenseRemove) {
        businessLicenseRemove.addEventListener('click', () => {
            businessLicenseInput.value = '';
            const previewImg = document.getElementById('businessLicensePreviewImg');
            if (previewImg) {
                previewImg.src = '';
                previewImg.classList.add('hidden');
            }
            businessLicenseUpload.classList.remove('hidden');
            businessLicensePreview.classList.add('hidden');
            
            if (updateProgress) updateProgress();
        });
    }

    // Land Certificate handlers
    if (landCertificateInput) {
        landCertificateInput.addEventListener('change', (e) => {
            const file = e.target.files[0];
            if (file) {
                if (file.size > 10 * 1024 * 1024) {
                    alert('File size must be less than 10MB');
                    return;
                }
                
                document.getElementById('landCertificateFileName').textContent = file.name;
                document.getElementById('landCertificateFileSize').textContent = formatFileSize(file.size);
                
                if (file.type.startsWith('image/')) {
                    const reader = new FileReader();
                    reader.onload = (e) => {
                        const previewImg = document.getElementById('landCertificatePreviewImg');
                        if (previewImg) {
                            previewImg.src = e.target.result;
                            previewImg.classList.remove('hidden');
                        }
                    };
                    reader.readAsDataURL(file);
                }
                
                landCertificateUpload.classList.add('hidden');
                landCertificatePreview.classList.remove('hidden');
                
                if (updateProgress) updateProgress();
            }
        });
    }

    if (landCertificateRemove) {
        landCertificateRemove.addEventListener('click', () => {
            landCertificateInput.value = '';
            const previewImg = document.getElementById('landCertificatePreviewImg');
            if (previewImg) {
                previewImg.src = '';
                previewImg.classList.add('hidden');
            }
            landCertificateUpload.classList.remove('hidden');
            landCertificatePreview.classList.add('hidden');
            
            if (updateProgress) updateProgress();
        });
    }

    // Photo Gallery handlers
    if (photoGalleryInput) {
        photoGalleryInput.addEventListener('change', (e) => {
            const files = Array.from(e.target.files);
            
            if (uploadedPhotos.length + files.length > 10) {
                alert('Maximum 10 photos allowed');
                return;
            }

            files.forEach(file => {
                if (file.size > 10 * 1024 * 1024) {
                    alert(`${file.name} is too large. Maximum 10MB per photo.`);
                    return;
                }

                const reader = new FileReader();
                reader.onload = (e) => {
                    const photoId = Date.now() + Math.random();
                    uploadedPhotos.push({ id: photoId, file: file, dataUrl: e.target.result });

                    const photoDiv = document.createElement('div');
                    photoDiv.className = 'aspect-square rounded-2xl bg-cover bg-center relative group';
                    photoDiv.style.backgroundImage = `url('${e.target.result}')`;
                    photoDiv.dataset.photoId = photoId;

                    const removeBtn = document.createElement('button');
                    removeBtn.type = 'button';
                    removeBtn.className = 'absolute -top-2 -right-2 size-8 bg-red-500 text-white rounded-full flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity shadow-lg';
                    removeBtn.innerHTML = '<span class="material-symbols-outlined text-sm">close</span>';
                    removeBtn.onclick = () => removePhoto(photoId);

                    photoDiv.appendChild(removeBtn);
                    photoGalleryContainer.insertBefore(photoDiv, photoUploadTrigger);
                    
                    if (updateProgress) updateProgress();
                };
                reader.readAsDataURL(file);
            });

            photoGalleryInput.value = '';
        });
    }

    function removePhoto(photoId) {
        uploadedPhotos = uploadedPhotos.filter(p => p.id !== photoId);
        const photoDiv = photoGalleryContainer.querySelector(`[data-photo-id="${photoId}"]`);
        if (photoDiv) photoDiv.remove();
        
        if (updateProgress) updateProgress();
    }

    // Save Progress button
    if (saveProgressBtn) {
        saveProgressBtn.addEventListener('click', () => {
            console.log('Saving progress...');
            
            const formData = {
                venueName: document.querySelector('input[placeholder*="Smash City Arena"]')?.value,
                sportTypes: Array.from(document.querySelectorAll('input[name="SportTypes"]:checked')).map(cb => cb.value),
                address: document.querySelector('input[placeholder*="physical location"]')?.value,
                businessLicense: businessLicenseInput?.files[0]?.name,
                landCertificate: landCertificateInput?.files[0]?.name,
                photoCount: uploadedPhotos.length
            };

            localStorage.setItem('venueRegistrationDraft', JSON.stringify({
                ...formData,
                savedAt: new Date().toISOString()
            }));

            const btn = saveProgressBtn;
            const originalHTML = btn.innerHTML;
            btn.innerHTML = '<span class="material-symbols-outlined text-base mr-2">check_circle</span>Saved!';
            btn.style.backgroundColor = '#22c55e';
            btn.style.color = 'white';
            btn.style.borderColor = '#22c55e';
            
            setTimeout(() => {
                btn.innerHTML = originalHTML;
                btn.style.backgroundColor = '';
                btn.style.color = '';
                btn.style.borderColor = '';
            }, 2000);

            console.log('Draft saved:', formData);
        });
    }

    // Attach progress tracking to form inputs
    const venueNameInput = document.querySelector('input[placeholder*="Smash City Arena"]');
    const addressInput = document.querySelector('input[placeholder*="physical location"]');
    const sportTypeCheckboxes = document.querySelectorAll('input[name="SportTypes"]');
    const amenityCheckboxes = document.querySelectorAll('.grid input[type="checkbox"]');

    if (venueNameInput) {
        venueNameInput.addEventListener('input', updateProgress);
        console.log('Venue name listener attached');
    }
    
    if (addressInput) {
        addressInput.addEventListener('input', updateProgress);
        console.log('Address listener attached');
    }
    
    sportTypeCheckboxes.forEach(cb => cb.addEventListener('change', updateProgress));
    amenityCheckboxes.forEach(cb => cb.addEventListener('change', updateProgress));

    console.log('Event listeners attached:', {
        venueNameInput: !!venueNameInput,
        addressInput: !!addressInput,
        sportTypes: sportTypeCheckboxes.length,
        amenities: amenityCheckboxes.length
    });

    // Handle Submit button
    const submitBtn = Array.from(document.querySelectorAll('button')).find(btn => btn.textContent.includes('Submit for Approval'));
    
    console.log('Submit button found:', submitBtn ? 'YES' : 'NO');
    
    if (submitBtn) {
        submitBtn.addEventListener('click', (e) => {
            console.log('Submit clicked');
            const result = updateProgress();
            
            if (!result.isValid) {
                e.preventDefault();
                alert('Please complete all required fields:\n- Venue Name\n- Sport Types\n- Address\n- Business License\n- Land Use Certificate');
                return false;
            }
            
            const confirmed = confirm('Submit venue registration for approval?');
            if (!confirmed) {
                e.preventDefault();
                return false;
            }
            
            console.log('Form submitted!');
        });
    }

    // Initial progress update
    setTimeout(() => {
        if (updateProgress) {
            updateProgress();
            console.log('Initial progress updated');
        }
    }, 100);

    // Load draft
    const draft = localStorage.getItem('venueRegistrationDraft');
    if (draft) {
        const data = JSON.parse(draft);
        console.log('Draft loaded:', data);
    }
});
