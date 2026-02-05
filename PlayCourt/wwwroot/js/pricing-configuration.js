document.addEventListener('DOMContentLoaded', () => {
    console.log('Pricing configuration script loaded');

    const peakHourContainer = document.getElementById('peakHourContainer');
    const addTimeSlotBtn = document.getElementById('addTimeSlotBtn');
    const savePricingBtn = document.getElementById('savePricingBtn');
    const weekendToggle = document.getElementById('weekendToggle');
    const baseRateInput = document.getElementById('baseRate');

    let slotCount = document.querySelectorAll('.peak-slot').length;

    // Add new time slot
    if (addTimeSlotBtn) {
        addTimeSlotBtn.addEventListener('click', () => {
            console.log('Add time slot clicked');
            
            if (slotCount >= 5) {
                alert('Maximum 5 peak hour slots allowed');
                return;
            }

            const slotId = Date.now();
            const slotHTML = `
                <div class="grid grid-cols-1 md:grid-cols-3 gap-6 p-6 bg-slate-50 dark:bg-slate-800/30 rounded-3xl border border-slate-200 dark:border-slate-700 relative group peak-slot" data-slot-id="${slotId}">
                    <div class="flex flex-col gap-2">
                        <label class="text-[10px] font-black uppercase tracking-widest text-slate-400">Start Time</label>
                        <div class="relative">
                            <span class="material-symbols-outlined absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 text-sm">schedule</span>
                            <input class="w-full bg-white dark:bg-slate-900 border-slate-200 dark:border-slate-700 rounded-xl py-3 pl-10 pr-4 font-bold text-sm text-slate-800 dark:text-slate-200 focus:ring-primary focus:border-primary" type="time" value="12:00"/>
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <label class="text-[10px] font-black uppercase tracking-widest text-slate-400">End Time</label>
                        <div class="relative">
                            <span class="material-symbols-outlined absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 text-sm">schedule</span>
                            <input class="w-full bg-white dark:bg-slate-900 border-slate-200 dark:border-slate-700 rounded-xl py-3 pl-10 pr-4 font-bold text-sm text-slate-800 dark:text-slate-200 focus:ring-primary focus:border-primary" type="time" value="14:00"/>
                        </div>
                    </div>
                    <div class="flex flex-col gap-2">
                        <label class="text-[10px] font-black uppercase tracking-widest text-slate-400">Peak Rate ($/hr)</label>
                        <div class="relative">
                            <span class="material-symbols-outlined absolute left-4 top-1/2 -translate-y-1/2 text-primary text-sm">trending_up</span>
                            <input class="w-full bg-white dark:bg-slate-900 border-slate-200 dark:border-slate-700 rounded-xl py-3 pl-10 pr-4 font-bold text-sm text-slate-800 dark:text-slate-200 focus:ring-primary focus:border-primary" placeholder="0.00" type="number" value=""/>
                        </div>
                    </div>
                    <button type="button" class="remove-slot-btn absolute -right-3 -top-3 size-8 bg-white dark:bg-slate-800 border border-slate-200 dark:border-slate-700 rounded-full flex items-center justify-center text-slate-400 hover:text-red-500 shadow-sm opacity-0 group-hover:opacity-100 transition-opacity">
                        <span class="material-symbols-outlined text-lg">close</span>
                    </button>
                </div>
            `;

            peakHourContainer.insertAdjacentHTML('beforeend', slotHTML);
            slotCount++;
            attachRemoveHandlers();
        });
    }

    // Remove time slot
    function attachRemoveHandlers() {
        document.querySelectorAll('.remove-slot-btn').forEach(btn => {
            btn.replaceWith(btn.cloneNode(true)); // Remove old listeners
        });

        document.querySelectorAll('.remove-slot-btn').forEach(btn => {
            btn.addEventListener('click', (e) => {
                const slot = e.currentTarget.closest('.peak-slot');
                if (slot) {
                    slot.remove();
                    slotCount--;
                    console.log('Slot removed. Remaining:', slotCount);
                }
            });
        });
    }

    // Initial attachment
    attachRemoveHandlers();

    // Weekend toggle
    if (weekendToggle) {
        weekendToggle.addEventListener('change', (e) => {
            console.log('Weekend pricing:', e.target.checked ? 'Enabled' : 'Disabled');
        });
    }

    // Save Draft
    const saveDraftBtn = Array.from(document.querySelectorAll('button')).find(btn => btn.textContent.includes('Save Draft'));
    if (saveDraftBtn) {
        saveDraftBtn.addEventListener('click', () => {
            console.log('Saving pricing draft...');
            savePricingData(false);
        });
    }

    // Save & Continue
    if (savePricingBtn) {
        savePricingBtn.addEventListener('click', () => {
            console.log('Saving pricing and continuing...');
            
            const baseRate = parseFloat(baseRateInput?.value || 0);
            
            if (baseRate <= 0) {
                alert('Please enter a valid Base Hourly Rate');
                return;
            }

            // Validate peak hour slots
            const slots = document.querySelectorAll('.peak-slot');
            let hasInvalidSlot = false;

            slots.forEach(slot => {
                const startTime = slot.querySelector('input[type="time"]').value;
                const endTime = slot.querySelectorAll('input[type="time"]')[1].value;
                const peakRate = parseFloat(slot.querySelector('input[type="number"]').value || 0);

                if (!startTime || !endTime || peakRate <= 0) {
                    hasInvalidSlot = true;
                }
            });

            if (hasInvalidSlot) {
                alert('Please complete all peak hour time slots or remove empty ones');
                return;
            }

            const confirmed = confirm('Save pricing configuration and continue to verification?');
            if (confirmed) {
                savePricingData(true);
                // TODO: Navigate to next step
                console.log('Pricing saved, ready for next step');
            }
        });
    }

    function savePricingData(isComplete) {
        const baseRate = parseFloat(baseRateInput?.value || 0);
        const enableWeekend = weekendToggle?.checked || false;

        const peakSlots = Array.from(document.querySelectorAll('.peak-slot')).map(slot => ({
            startTime: slot.querySelector('input[type="time"]').value,
            endTime: slot.querySelectorAll('input[type="time"]')[1].value,
            peakRate: parseFloat(slot.querySelector('input[type="number"]').value || 0)
        }));

        const pricingData = {
            baseHourlyRate: baseRate,
            enableWeekendPricing: enableWeekend,
            peakHourSlots: peakSlots,
            savedAt: new Date().toISOString(),
            isComplete: isComplete
        };

        localStorage.setItem('venuePricingDraft', JSON.stringify(pricingData));
        console.log('Pricing data saved:', pricingData);

        if (!isComplete) {
            const btn = Array.from(document.querySelectorAll('button')).find(b => b.textContent.includes('Save Draft'));
            if (btn) {
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
            }
        }
    }

    // Load draft
    const draft = localStorage.getItem('venuePricingDraft');
    if (draft) {
        const data = JSON.parse(draft);
        console.log('Pricing draft loaded:', data);
        
        if (baseRateInput && data.baseHourlyRate) {
            baseRateInput.value = data.baseHourlyRate;
        }
        
        if (weekendToggle && data.enableWeekendPricing) {
            weekendToggle.checked = true;
        }
    }
});
