using AlcoholViolationManagement.Domain.DTOs;
using AlcoholViolationManagement.Domain.Enums;

namespace AlcoholViolationManagement.DAL.Interfaces;

public interface IThongKeRepository
{
    Task<ThongKeTongHop> GetTongHopAsync(DateTime tuNgay, DateTime denNgay);
    Task<IReadOnlyList<ThongKeNhomRow>> GetTheoNhomAsync(NhomThongKe nhom, DateTime tuNgay, DateTime denNgay);
}
