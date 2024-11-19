using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;
public enum ProjectSubmissionStatus
{                      // Taslak -->Draft hali front'ta olacak. Cookie'lere kaydet.
    UnderReview,      // İnceleniyor
    Accepted,         // Kabul edildi
    RevisionsNeeded,  // Revizyon gerekli
    Finalized,        // Nihai hali
    Rejected          // Reddedildi
}
