using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaritimeResumeParser.Domain.Models
{
    public class ExtractionMetadata
    {
        public int InputTokens { get; set; }
        public int OutputTokens { get; set; }
        public int TotalTokens { get; set; }
        public decimal EstimatedCostInr { get; set; }
    }

    public class MaritimeCvExtractionResult
    {
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [JsonPropertyName("_metadata")]
        public ExtractionMetadata? Metadata { get; set; }

        [JsonPropertyName("personal_details")]
        public PersonalDetail PersonalDetails { get; set; } = new PersonalDetail();

        [JsonPropertyName("passport_details")]
        public PassportDetail PassportDetails { get; set; } = new PassportDetail();

        [JsonPropertyName("visa_records")]
        public List<VisaDetails> VisaRecords { get; set; } = new List<VisaDetails>();

        [JsonPropertyName("seamen_book_records")]
        public List<SeamenBooks> SeamenBookRecords { get; set; } = new List<SeamenBooks>();

        [JsonPropertyName("coc_records")]
        public List<CocDetails> CocRecords { get; set; } = new List<CocDetails>();

        [JsonPropertyName("dce_records")]
        public List<DceDetails> DceRecords { get; set; } = new List<DceDetails>();

        [JsonPropertyName("academic_records")]
        public List<AcademicDetails> AcademicRecords { get; set; } = new List<AcademicDetails>();

        [JsonPropertyName("course_records")]
        public List<CourseDetails> CourseRecords { get; set; } = new List<CourseDetails>();

        [JsonPropertyName("sea_service_records")]
        public List<SeaServiceRecord> SeaServiceRecords { get; set; } = new List<SeaServiceRecord>();

        [JsonPropertyName("availability")]
        public CandidateAvailability Availability { get; set; } = new CandidateAvailability();

        [JsonPropertyName("medical_records")]
        public MedicalCertificate MedicalRecords { get; set; } = new MedicalCertificate();
    }

    public class PersonalDetail
    {
        public int student_id { get; set; }
        public string? first_name { get; set; }
        public string? middle_name { get; set; }
        public string? last_name { get; set; }
        public string? father_name { get; set; }
        public string? mother_name { get; set; }
        public string? email { get; set; }
        public string? country_code { get; set; }
        public string? mobile { get; set; }
        public string? alt_country_code { get; set; }
        public string? alt_mobile { get; set; }
        public DateTime? dob { get; set; }
        public string? indos_no { get; set; }
        public string? gender { get; set; }
        public string? marital_status { get; set; }
        public int? no_of_children { get; set; }
        public string? current_address { get; set; }
        public int? country_id { get; set; }
        public int? state_id { get; set; }
        public int? city_id { get; set; }
        public string? nearest_airport { get; set; }
        public string? pincode { get; set; }
        public bool? same_as_current { get; set; }
        public string? perm_address { get; set; }
        public int? perm_country_id { get; set; }
        public int? perm_state_id { get; set; }
        public int? perm_city_id { get; set; }
        public string? career_desc { get; set; }
        public DateTime? created_at { get; set; }

        public PassportDetail? PassportDetail { get; set; }
        public CandidateAvailability? Availability { get; set; }
        public MedicalCertificate? MedicalCertificate { get; set; }
        public IList<VisaDetails> VisaRecords { get; set; } = new List<VisaDetails>();
        public IList<SeamenBooks> SeamenBooks { get; set; } = new List<SeamenBooks>();
        public IList<CocDetails> CocDetails { get; set; } = new List<CocDetails>();
        public IList<DceDetails> DceDetails { get; set; } = new List<DceDetails>();
        public IList<AcademicDetails> AcademicDetails { get; set; } = new List<AcademicDetails>();
        public IList<CourseDetails> CourseDetails { get; set; } = new List<CourseDetails>();
        public IList<SeaServiceRecord> SeaServiceRecords { get; set; } = new List<SeaServiceRecord>();
    }

    public class PassportDetail
    {
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? nationality { get; set; }
        public string? passport_no { get; set; }
        public DateTime? date_of_issue { get; set; }
        public DateTime? date_of_expiry { get; set; }
        public string? place_of_issue { get; set; }
        public int? blank_pages { get; set; }
        public DateTime? created_at { get; set; }
        public string? firstpage { get; set; }
        public string? lastpage { get; set; }
        public bool? damage { get; set; }
    }

    public class VisaDetails
    {
        public int Id { get; set; }
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public bool? is_us_visa { get; set; }
        public string? country { get; set; }
        public string? visa_type { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? expiry_date { get; set; }
        public string? file_path { get; set; }
        public DateTime? created_at { get; set; }
    }

    public class SeamenBooks
    {
        public int Id { get; set; }
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? cdc_no { get; set; }
        public string? country { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? expiry_date { get; set; }
        public DateTime? created_at { get; set; }
        public string? file_path { get; set; }
        public bool? is_national { get; set; }
    }

    public class CocDetails
    {
        public int Id { get; set; }
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? cert_type { get; set; }
        public string? issuing_country { get; set; }
        public string? cert_no { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? expiry_date { get; set; }
        public string? file_path { get; set; }
        public DateTime? created_at { get; set; }
        public bool? is_national { get; set; }
    }

    public class DceDetails
    {
        public int Id { get; set; }
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? tanker_type { get; set; }
        public string? country { get; set; }
        public string? level { get; set; }
        public string? cert_no { get; set; }
        public DateTime? valid_date { get; set; }
        public string? file_path { get; set; }
        public bool is_national { get; set; }
        public DateTime? created_at { get; set; }
    }

    public class AcademicDetails
    {
        public int Id { get; set; }
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? qualification_type { get; set; }
        public string? institute { get; set; }
        public string? stream { get; set; }
        public short? passing_year { get; set; }
        public string? percentage_grade { get; set; }
        public string? file_path { get; set; }
        public DateTime? created_at { get; set; }
    }

    public class CourseDetails
    {
        public int Id { get; set; }
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? course_name { get; set; }
        public string? institute { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? expiry_date { get; set; }
        public string? file_path { get; set; }
        public DateTime? created_at { get; set; }
    }

    public class SeaServiceRecord
    {
        public int Id { get; set; }
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? rank { get; set; }
        public string? ship_type { get; set; }
        public string? company { get; set; }
        public string? vessel_name { get; set; }
        public string? dwt { get; set; }
        public DateTime? sign_on { get; set; }
        public DateTime? sign_off { get; set; }
        public string? reason { get; set; }
        public string? imo_no { get; set; }
        public DateTime? created_at { get; set; }
    }

    public class CandidateAvailability
    {
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public string? rank { get; set; }
        public string? vessle_type { get; set; }
        public DateTime? available_from { get; set; }
        public DateTime? created_at { get; set; }
    }

    public class MedicalCertificate
    {
        public int student_id { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public DateTime? issue_date { get; set; }
        public DateTime? valid_till_date { get; set; }
        public bool yellow_fever { get; set; }
        public DateTime? yellow_fever_date { get; set; }
        public string? file_path { get; set; }
    }
}
