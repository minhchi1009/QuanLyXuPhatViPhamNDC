using AlcoholViolationManagement.WinForms.Controls;

namespace AlcoholViolationManagement.WinForms.Forms;

partial class CatalogForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        rootLayout = new TableLayoutPanel();
        panelTabs = new Panel();
        btnLoaiPhuongTien = new RoundedButton();
        btnMucNongDo = new RoundedButton();
        btnLoaiViPham = new RoundedButton();
        lblTabHint = new Label();
        panelHost = new Panel();
        panelLoaiPhuongTien = new Panel();
        cardLoaiPhuongTien = new RoundedPanel();
        panelHeaderLoaiPhuongTien = new Panel();
        lblTitleLoaiPhuongTien = new Label();
        lblHintLoaiPhuongTien = new Label();
        btnThemLoaiPhuongTien = new RoundedButton();
        gridHostLoaiPhuongTien = new Panel();
        gridLoaiPhuongTien = new BufferedDataGridView();
        colMaLoaiPhuongTien = new DataGridViewTextBoxColumn();
        colTenPhuongTien = new DataGridViewTextBoxColumn();
        colMoTaPhuongTien = new DataGridViewTextBoxColumn();
        panelMucNongDo = new Panel();
        cardMucNongDo = new RoundedPanel();
        panelHeaderMucNongDo = new Panel();
        lblTitleMucNongDo = new Label();
        lblHintMucNongDo = new Label();
        btnThemMucNongDo = new RoundedButton();
        gridHostMucNongDo = new Panel();
        gridMucNongDo = new BufferedDataGridView();
        colMaMucNongDo = new DataGridViewTextBoxColumn();
        colKhoangGiaTri = new DataGridViewTextBoxColumn();
        colNguongTren = new DataGridViewTextBoxColumn();
        colMoTaMucNongDo = new DataGridViewTextBoxColumn();
        panelLoaiViPham = new Panel();
        cardLoaiViPham = new RoundedPanel();
        panelHeaderLoaiViPham = new Panel();
        lblTitleLoaiViPham = new Label();
        lblHintLoaiViPham = new Label();
        btnThemLoaiViPham = new RoundedButton();
        gridHostLoaiViPham = new Panel();
        gridLoaiViPham = new BufferedDataGridView();
        colMaLoaiViPham = new DataGridViewTextBoxColumn();
        colTenLoaiViPham = new DataGridViewTextBoxColumn();
        colTenPhuongTienViPham = new DataGridViewTextBoxColumn();
        colKhoangGiaTriViPham = new DataGridViewTextBoxColumn();
        colMucPhat = new DataGridViewTextBoxColumn();
        colMoTaViPham = new DataGridViewTextBoxColumn();
        rootLayout.SuspendLayout();
        panelTabs.SuspendLayout();
        panelHost.SuspendLayout();
        panelLoaiPhuongTien.SuspendLayout();
        cardLoaiPhuongTien.SuspendLayout();
        panelHeaderLoaiPhuongTien.SuspendLayout();
        gridHostLoaiPhuongTien.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridLoaiPhuongTien).BeginInit();
        panelMucNongDo.SuspendLayout();
        cardMucNongDo.SuspendLayout();
        panelHeaderMucNongDo.SuspendLayout();
        gridHostMucNongDo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridMucNongDo).BeginInit();
        panelLoaiViPham.SuspendLayout();
        cardLoaiViPham.SuspendLayout();
        panelHeaderLoaiViPham.SuspendLayout();
        gridHostLoaiViPham.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridLoaiViPham).BeginInit();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(panelTabs, 0, 0);
        rootLayout.Controls.Add(panelHost, 0, 1);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 2;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1130, 748);
        rootLayout.TabIndex = 0;
        // 
        // panelTabs
        // 
        panelTabs.Controls.Add(btnLoaiPhuongTien);
        panelTabs.Controls.Add(btnMucNongDo);
        panelTabs.Controls.Add(btnLoaiViPham);
        panelTabs.Controls.Add(lblTabHint);
        panelTabs.Dock = DockStyle.Fill;
        panelTabs.Location = new Point(0, 0);
        panelTabs.Margin = new Padding(0, 0, 0, 14);
        panelTabs.Name = "panelTabs";
        panelTabs.Size = new Size(1130, 42);
        panelTabs.TabIndex = 0;
        // 
        // btnLoaiPhuongTien
        // 
        btnLoaiPhuongTien.BackColor = Color.Transparent;
        btnLoaiPhuongTien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnLoaiPhuongTien.Location = new Point(0, 2);
        btnLoaiPhuongTien.Name = "btnLoaiPhuongTien";
        btnLoaiPhuongTien.Size = new Size(190, 38);
        btnLoaiPhuongTien.TabIndex = 0;
        btnLoaiPhuongTien.Text = "Loại phương tiện";
        btnLoaiPhuongTien.Variant = ButtonVariant.Primary;
        // 
        // btnMucNongDo
        // 
        btnMucNongDo.BackColor = Color.Transparent;
        btnMucNongDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnMucNongDo.Location = new Point(198, 2);
        btnMucNongDo.Name = "btnMucNongDo";
        btnMucNongDo.Size = new Size(190, 38);
        btnMucNongDo.TabIndex = 1;
        btnMucNongDo.Text = "Mức nồng độ cồn";
        btnMucNongDo.Variant = ButtonVariant.Secondary;
        // 
        // btnLoaiViPham
        // 
        btnLoaiViPham.BackColor = Color.Transparent;
        btnLoaiViPham.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnLoaiViPham.Location = new Point(396, 2);
        btnLoaiViPham.Name = "btnLoaiViPham";
        btnLoaiViPham.Size = new Size(190, 38);
        btnLoaiViPham.TabIndex = 2;
        btnLoaiViPham.Text = "Loại vi phạm";
        btnLoaiViPham.Variant = ButtonVariant.Secondary;
        // 
        // lblTabHint
        // 
        lblTabHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTabHint.Font = new Font("Segoe UI", 8F);
        lblTabHint.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblTabHint.Location = new Point(700, 12);
        lblTabHint.Name = "lblTabHint";
        lblTabHint.Size = new Size(430, 18);
        lblTabHint.TabIndex = 3;
        lblTabHint.Text = "Danh mục dùng chung cho biên bản, quyết định và mức xử phạt";
        lblTabHint.TextAlign = ContentAlignment.TopRight;
        // 
        // panelHost
        // 
        panelHost.Controls.Add(panelLoaiPhuongTien);
        panelHost.Controls.Add(panelMucNongDo);
        panelHost.Controls.Add(panelLoaiViPham);
        panelHost.Dock = DockStyle.Fill;
        panelHost.Location = new Point(0, 56);
        panelHost.Margin = new Padding(0);
        panelHost.Name = "panelHost";
        panelHost.Size = new Size(1130, 692);
        panelHost.TabIndex = 1;
        // 
        // panelLoaiPhuongTien
        // 
        panelLoaiPhuongTien.Controls.Add(cardLoaiPhuongTien);
        panelLoaiPhuongTien.Dock = DockStyle.Fill;
        panelLoaiPhuongTien.Location = new Point(0, 0);
        panelLoaiPhuongTien.Name = "panelLoaiPhuongTien";
        panelLoaiPhuongTien.Size = new Size(1130, 692);
        panelLoaiPhuongTien.TabIndex = 0;
        // 
        // cardLoaiPhuongTien
        // 
        cardLoaiPhuongTien.BackColor = Color.White;
        cardLoaiPhuongTien.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardLoaiPhuongTien.Controls.Add(panelHeaderLoaiPhuongTien);
        cardLoaiPhuongTien.Controls.Add(gridHostLoaiPhuongTien);
        cardLoaiPhuongTien.CornerRadius = 14;
        cardLoaiPhuongTien.Dock = DockStyle.Fill;
        cardLoaiPhuongTien.Location = new Point(0, 0);
        cardLoaiPhuongTien.Margin = new Padding(0);
        cardLoaiPhuongTien.Name = "cardLoaiPhuongTien";
        cardLoaiPhuongTien.Size = new Size(1130, 692);
        cardLoaiPhuongTien.TabIndex = 0;
        // 
        // panelHeaderLoaiPhuongTien
        // 
        panelHeaderLoaiPhuongTien.Controls.Add(lblTitleLoaiPhuongTien);
        panelHeaderLoaiPhuongTien.Controls.Add(lblHintLoaiPhuongTien);
        panelHeaderLoaiPhuongTien.Controls.Add(btnThemLoaiPhuongTien);
        panelHeaderLoaiPhuongTien.Dock = DockStyle.Top;
        panelHeaderLoaiPhuongTien.Location = new Point(0, 0);
        panelHeaderLoaiPhuongTien.Name = "panelHeaderLoaiPhuongTien";
        panelHeaderLoaiPhuongTien.Size = new Size(1130, 60);
        panelHeaderLoaiPhuongTien.TabIndex = 0;
        // 
        // lblTitleLoaiPhuongTien
        // 
        lblTitleLoaiPhuongTien.Font = new Font("Segoe UI Semibold", 10.5F);
        lblTitleLoaiPhuongTien.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblTitleLoaiPhuongTien.Location = new Point(20, 19);
        lblTitleLoaiPhuongTien.Name = "lblTitleLoaiPhuongTien";
        lblTitleLoaiPhuongTien.Size = new Size(300, 22);
        lblTitleLoaiPhuongTien.TabIndex = 0;
        lblTitleLoaiPhuongTien.Text = "Loại phương tiện";
        // 
        // lblHintLoaiPhuongTien
        // 
        lblHintLoaiPhuongTien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHintLoaiPhuongTien.Font = new Font("Segoe UI", 8F);
        lblHintLoaiPhuongTien.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHintLoaiPhuongTien.Location = new Point(560, 22);
        lblHintLoaiPhuongTien.Name = "lblHintLoaiPhuongTien";
        lblHintLoaiPhuongTien.Size = new Size(400, 18);
        lblHintLoaiPhuongTien.TabIndex = 1;
        lblHintLoaiPhuongTien.Text = "Đang tải danh mục...";
        lblHintLoaiPhuongTien.TextAlign = ContentAlignment.TopRight;
        // 
        // btnThemLoaiPhuongTien
        // 
        btnThemLoaiPhuongTien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThemLoaiPhuongTien.BackColor = Color.Transparent;
        btnThemLoaiPhuongTien.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnThemLoaiPhuongTien.Glyph = "\uE710";
        btnThemLoaiPhuongTien.GlyphSize = 9F;
        btnThemLoaiPhuongTien.Location = new Point(974, 12);
        btnThemLoaiPhuongTien.Name = "btnThemLoaiPhuongTien";
        btnThemLoaiPhuongTien.Size = new Size(136, 36);
        btnThemLoaiPhuongTien.TabIndex = 2;
        btnThemLoaiPhuongTien.Text = "Thêm mới";
        btnThemLoaiPhuongTien.Variant = ButtonVariant.Primary;
        // 
        // gridHostLoaiPhuongTien
        // 
        gridHostLoaiPhuongTien.Controls.Add(gridLoaiPhuongTien);
        gridHostLoaiPhuongTien.Dock = DockStyle.Fill;
        gridHostLoaiPhuongTien.Location = new Point(0, 0);
        gridHostLoaiPhuongTien.Name = "gridHostLoaiPhuongTien";
        gridHostLoaiPhuongTien.Padding = new Padding(0, 60, 0, 0);
        gridHostLoaiPhuongTien.Size = new Size(1130, 692);
        gridHostLoaiPhuongTien.TabIndex = 1;
        // 
        // gridLoaiPhuongTien
        // 
        gridLoaiPhuongTien.AllowUserToAddRows = false;
        gridLoaiPhuongTien.AllowUserToDeleteRows = false;
        gridLoaiPhuongTien.AllowUserToResizeRows = false;
        gridLoaiPhuongTien.AutoGenerateColumns = false;
        gridLoaiPhuongTien.BackgroundColor = Color.White;
        gridLoaiPhuongTien.BorderStyle = BorderStyle.None;
        gridLoaiPhuongTien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridLoaiPhuongTien.ColumnHeadersHeight = 42;
        gridLoaiPhuongTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridLoaiPhuongTien.Columns.AddRange(new DataGridViewColumn[] { colMaLoaiPhuongTien, colTenPhuongTien, colMoTaPhuongTien });
        gridLoaiPhuongTien.Dock = DockStyle.Fill;
        gridLoaiPhuongTien.Location = new Point(0, 60);
        gridLoaiPhuongTien.MultiSelect = false;
        gridLoaiPhuongTien.Name = "gridLoaiPhuongTien";
        gridLoaiPhuongTien.ReadOnly = true;
        gridLoaiPhuongTien.RowHeadersVisible = false;
        gridLoaiPhuongTien.RowTemplate.Height = 42;
        gridLoaiPhuongTien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridLoaiPhuongTien.Size = new Size(1130, 632);
        gridLoaiPhuongTien.TabIndex = 0;
        // 
        // colMaLoaiPhuongTien
        // 
        colMaLoaiPhuongTien.DataPropertyName = "MaLoaiPhuongTien";
        colMaLoaiPhuongTien.FillWeight = 95F;
        colMaLoaiPhuongTien.HeaderText = "Mã loại phương tiện";
        colMaLoaiPhuongTien.MinimumWidth = 130;
        colMaLoaiPhuongTien.Name = "colMaLoaiPhuongTien";
        // 
        // colTenPhuongTien
        // 
        colTenPhuongTien.DataPropertyName = "TenPhuongTien";
        colTenPhuongTien.FillWeight = 150F;
        colTenPhuongTien.HeaderText = "Tên loại phương tiện";
        colTenPhuongTien.MinimumWidth = 200;
        colTenPhuongTien.Name = "colTenPhuongTien";
        // 
        // colMoTaPhuongTien
        // 
        colMoTaPhuongTien.DataPropertyName = "MoTa";
        colMoTaPhuongTien.FillWeight = 300F;
        colMoTaPhuongTien.HeaderText = "Mô tả";
        colMoTaPhuongTien.MinimumWidth = 300;
        colMoTaPhuongTien.Name = "colMoTaPhuongTien";
        // 
        // panelMucNongDo
        // 
        panelMucNongDo.Controls.Add(cardMucNongDo);
        panelMucNongDo.Dock = DockStyle.Fill;
        panelMucNongDo.Location = new Point(0, 0);
        panelMucNongDo.Name = "panelMucNongDo";
        panelMucNongDo.Size = new Size(1130, 692);
        panelMucNongDo.TabIndex = 1;
        panelMucNongDo.Visible = false;
        // 
        // cardMucNongDo
        // 
        cardMucNongDo.BackColor = Color.White;
        cardMucNongDo.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardMucNongDo.Controls.Add(panelHeaderMucNongDo);
        cardMucNongDo.Controls.Add(gridHostMucNongDo);
        cardMucNongDo.CornerRadius = 14;
        cardMucNongDo.Dock = DockStyle.Fill;
        cardMucNongDo.Location = new Point(0, 0);
        cardMucNongDo.Margin = new Padding(0);
        cardMucNongDo.Name = "cardMucNongDo";
        cardMucNongDo.Size = new Size(1130, 692);
        cardMucNongDo.TabIndex = 0;
        // 
        // panelHeaderMucNongDo
        // 
        panelHeaderMucNongDo.Controls.Add(lblTitleMucNongDo);
        panelHeaderMucNongDo.Controls.Add(lblHintMucNongDo);
        panelHeaderMucNongDo.Controls.Add(btnThemMucNongDo);
        panelHeaderMucNongDo.Dock = DockStyle.Top;
        panelHeaderMucNongDo.Location = new Point(0, 0);
        panelHeaderMucNongDo.Name = "panelHeaderMucNongDo";
        panelHeaderMucNongDo.Size = new Size(1130, 60);
        panelHeaderMucNongDo.TabIndex = 0;
        // 
        // lblTitleMucNongDo
        // 
        lblTitleMucNongDo.Font = new Font("Segoe UI Semibold", 10.5F);
        lblTitleMucNongDo.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblTitleMucNongDo.Location = new Point(20, 19);
        lblTitleMucNongDo.Name = "lblTitleMucNongDo";
        lblTitleMucNongDo.Size = new Size(300, 22);
        lblTitleMucNongDo.TabIndex = 0;
        lblTitleMucNongDo.Text = "Mức nồng độ cồn";
        // 
        // lblHintMucNongDo
        // 
        lblHintMucNongDo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHintMucNongDo.Font = new Font("Segoe UI", 8F);
        lblHintMucNongDo.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHintMucNongDo.Location = new Point(560, 22);
        lblHintMucNongDo.Name = "lblHintMucNongDo";
        lblHintMucNongDo.Size = new Size(400, 18);
        lblHintMucNongDo.TabIndex = 1;
        lblHintMucNongDo.Text = "Đang tải danh mục...";
        lblHintMucNongDo.TextAlign = ContentAlignment.TopRight;
        // 
        // btnThemMucNongDo
        // 
        btnThemMucNongDo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThemMucNongDo.BackColor = Color.Transparent;
        btnThemMucNongDo.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnThemMucNongDo.Glyph = "\uE710";
        btnThemMucNongDo.GlyphSize = 9F;
        btnThemMucNongDo.Location = new Point(974, 12);
        btnThemMucNongDo.Name = "btnThemMucNongDo";
        btnThemMucNongDo.Size = new Size(136, 36);
        btnThemMucNongDo.TabIndex = 2;
        btnThemMucNongDo.Text = "Thêm mới";
        btnThemMucNongDo.Variant = ButtonVariant.Primary;
        // 
        // gridHostMucNongDo
        // 
        gridHostMucNongDo.Controls.Add(gridMucNongDo);
        gridHostMucNongDo.Dock = DockStyle.Fill;
        gridHostMucNongDo.Location = new Point(0, 0);
        gridHostMucNongDo.Name = "gridHostMucNongDo";
        gridHostMucNongDo.Padding = new Padding(0, 60, 0, 0);
        gridHostMucNongDo.Size = new Size(1130, 692);
        gridHostMucNongDo.TabIndex = 1;
        // 
        // gridMucNongDo
        // 
        gridMucNongDo.AllowUserToAddRows = false;
        gridMucNongDo.AllowUserToDeleteRows = false;
        gridMucNongDo.AllowUserToResizeRows = false;
        gridMucNongDo.AutoGenerateColumns = false;
        gridMucNongDo.BackgroundColor = Color.White;
        gridMucNongDo.BorderStyle = BorderStyle.None;
        gridMucNongDo.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridMucNongDo.ColumnHeadersHeight = 42;
        gridMucNongDo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridMucNongDo.Columns.AddRange(new DataGridViewColumn[] { colMaMucNongDo, colKhoangGiaTri, colNguongTren, colMoTaMucNongDo });
        gridMucNongDo.Dock = DockStyle.Fill;
        gridMucNongDo.Location = new Point(0, 60);
        gridMucNongDo.MultiSelect = false;
        gridMucNongDo.Name = "gridMucNongDo";
        gridMucNongDo.ReadOnly = true;
        gridMucNongDo.RowHeadersVisible = false;
        gridMucNongDo.RowTemplate.Height = 42;
        gridMucNongDo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridMucNongDo.Size = new Size(1130, 632);
        gridMucNongDo.TabIndex = 0;
        // 
        // colMaMucNongDo
        // 
        colMaMucNongDo.DataPropertyName = "MaMucNongDoCon";
        colMaMucNongDo.FillWeight = 95F;
        colMaMucNongDo.HeaderText = "Mã mức";
        colMaMucNongDo.MinimumWidth = 130;
        colMaMucNongDo.Name = "colMaMucNongDo";
        // 
        // colKhoangGiaTri
        // 
        colKhoangGiaTri.DataPropertyName = "KhoangGiaTri";
        colKhoangGiaTri.FillWeight = 150F;
        colKhoangGiaTri.HeaderText = "Khoảng giá trị";
        colKhoangGiaTri.MinimumWidth = 180;
        colKhoangGiaTri.Name = "colKhoangGiaTri";
        // 
        // colNguongTren
        // 
        colNguongTren.DataPropertyName = "NguongTren";
        colNguongTren.FillWeight = 110F;
        colNguongTren.HeaderText = "Ngưỡng trên";
        colNguongTren.MinimumWidth = 140;
        colNguongTren.Name = "colNguongTren";
        // 
        // colMoTaMucNongDo
        // 
        colMoTaMucNongDo.DataPropertyName = "MoTa";
        colMoTaMucNongDo.FillWeight = 250F;
        colMoTaMucNongDo.HeaderText = "Mô tả";
        colMoTaMucNongDo.MinimumWidth = 260;
        colMoTaMucNongDo.Name = "colMoTaMucNongDo";
        // 
        // panelLoaiViPham
        // 
        panelLoaiViPham.Controls.Add(cardLoaiViPham);
        panelLoaiViPham.Dock = DockStyle.Fill;
        panelLoaiViPham.Location = new Point(0, 0);
        panelLoaiViPham.Name = "panelLoaiViPham";
        panelLoaiViPham.Size = new Size(1130, 692);
        panelLoaiViPham.TabIndex = 2;
        panelLoaiViPham.Visible = false;
        // 
        // cardLoaiViPham
        // 
        cardLoaiViPham.BackColor = Color.White;
        cardLoaiViPham.BorderColor = ColorTranslator.FromHtml("#E9EEF5");
        cardLoaiViPham.Controls.Add(panelHeaderLoaiViPham);
        cardLoaiViPham.Controls.Add(gridHostLoaiViPham);
        cardLoaiViPham.CornerRadius = 14;
        cardLoaiViPham.Dock = DockStyle.Fill;
        cardLoaiViPham.Location = new Point(0, 0);
        cardLoaiViPham.Margin = new Padding(0);
        cardLoaiViPham.Name = "cardLoaiViPham";
        cardLoaiViPham.Size = new Size(1130, 692);
        cardLoaiViPham.TabIndex = 0;
        // 
        // panelHeaderLoaiViPham
        // 
        panelHeaderLoaiViPham.Controls.Add(lblTitleLoaiViPham);
        panelHeaderLoaiViPham.Controls.Add(lblHintLoaiViPham);
        panelHeaderLoaiViPham.Controls.Add(btnThemLoaiViPham);
        panelHeaderLoaiViPham.Dock = DockStyle.Top;
        panelHeaderLoaiViPham.Location = new Point(0, 0);
        panelHeaderLoaiViPham.Name = "panelHeaderLoaiViPham";
        panelHeaderLoaiViPham.Size = new Size(1130, 60);
        panelHeaderLoaiViPham.TabIndex = 0;
        // 
        // lblTitleLoaiViPham
        // 
        lblTitleLoaiViPham.Font = new Font("Segoe UI Semibold", 10.5F);
        lblTitleLoaiViPham.ForeColor = ColorTranslator.FromHtml("#16202A");
        lblTitleLoaiViPham.Location = new Point(20, 19);
        lblTitleLoaiViPham.Name = "lblTitleLoaiViPham";
        lblTitleLoaiViPham.Size = new Size(300, 22);
        lblTitleLoaiViPham.TabIndex = 0;
        lblTitleLoaiViPham.Text = "Loại vi phạm và mức xử phạt";
        // 
        // lblHintLoaiViPham
        // 
        lblHintLoaiViPham.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHintLoaiViPham.Font = new Font("Segoe UI", 8F);
        lblHintLoaiViPham.ForeColor = ColorTranslator.FromHtml("#8A96A3");
        lblHintLoaiViPham.Location = new Point(520, 22);
        lblHintLoaiViPham.Name = "lblHintLoaiViPham";
        lblHintLoaiViPham.Size = new Size(440, 18);
        lblHintLoaiViPham.TabIndex = 1;
        lblHintLoaiViPham.Text = "Đang tải danh mục...";
        lblHintLoaiViPham.TextAlign = ContentAlignment.TopRight;
        // 
        // btnThemLoaiViPham
        // 
        btnThemLoaiViPham.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThemLoaiViPham.BackColor = Color.Transparent;
        btnThemLoaiViPham.Font = new Font("Segoe UI", 8.75F, FontStyle.Bold);
        btnThemLoaiViPham.Glyph = "\uE710";
        btnThemLoaiViPham.GlyphSize = 9F;
        btnThemLoaiViPham.Location = new Point(974, 12);
        btnThemLoaiViPham.Name = "btnThemLoaiViPham";
        btnThemLoaiViPham.Size = new Size(136, 36);
        btnThemLoaiViPham.TabIndex = 2;
        btnThemLoaiViPham.Text = "Thêm mới";
        btnThemLoaiViPham.Variant = ButtonVariant.Primary;
        // 
        // gridHostLoaiViPham
        // 
        gridHostLoaiViPham.Controls.Add(gridLoaiViPham);
        gridHostLoaiViPham.Dock = DockStyle.Fill;
        gridHostLoaiViPham.Location = new Point(0, 0);
        gridHostLoaiViPham.Name = "gridHostLoaiViPham";
        gridHostLoaiViPham.Padding = new Padding(0, 60, 0, 0);
        gridHostLoaiViPham.Size = new Size(1130, 692);
        gridHostLoaiViPham.TabIndex = 1;
        // 
        // gridLoaiViPham
        // 
        gridLoaiViPham.AllowUserToAddRows = false;
        gridLoaiViPham.AllowUserToDeleteRows = false;
        gridLoaiViPham.AllowUserToResizeRows = false;
        gridLoaiViPham.AutoGenerateColumns = false;
        gridLoaiViPham.BackgroundColor = Color.White;
        gridLoaiViPham.BorderStyle = BorderStyle.None;
        gridLoaiViPham.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridLoaiViPham.ColumnHeadersHeight = 42;
        gridLoaiViPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridLoaiViPham.Columns.AddRange(new DataGridViewColumn[] { colMaLoaiViPham, colTenLoaiViPham, colTenPhuongTienViPham, colKhoangGiaTriViPham, colMucPhat, colMoTaViPham });
        gridLoaiViPham.Dock = DockStyle.Fill;
        gridLoaiViPham.Location = new Point(0, 60);
        gridLoaiViPham.MultiSelect = false;
        gridLoaiViPham.Name = "gridLoaiViPham";
        gridLoaiViPham.ReadOnly = true;
        gridLoaiViPham.RowHeadersVisible = false;
        gridLoaiViPham.RowTemplate.Height = 42;
        gridLoaiViPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridLoaiViPham.Size = new Size(1130, 632);
        gridLoaiViPham.TabIndex = 0;
        // 
        // colMaLoaiViPham
        // 
        colMaLoaiViPham.DataPropertyName = "MaLoaiViPham";
        colMaLoaiViPham.FillWeight = 85F;
        colMaLoaiViPham.HeaderText = "Mã loại vi phạm";
        colMaLoaiViPham.MinimumWidth = 120;
        colMaLoaiViPham.Name = "colMaLoaiViPham";
        // 
        // colTenLoaiViPham
        // 
        colTenLoaiViPham.DataPropertyName = "TenLoaiViPham";
        colTenLoaiViPham.FillWeight = 150F;
        colTenLoaiViPham.HeaderText = "Tên loại vi phạm";
        colTenLoaiViPham.MinimumWidth = 200;
        colTenLoaiViPham.Name = "colTenLoaiViPham";
        // 
        // colTenPhuongTienViPham
        // 
        colTenPhuongTienViPham.DataPropertyName = "TenPhuongTien";
        colTenPhuongTienViPham.FillWeight = 100F;
        colTenPhuongTienViPham.HeaderText = "Loại phương tiện";
        colTenPhuongTienViPham.MinimumWidth = 130;
        colTenPhuongTienViPham.Name = "colTenPhuongTienViPham";
        // 
        // colKhoangGiaTriViPham
        // 
        colKhoangGiaTriViPham.DataPropertyName = "KhoangGiaTri";
        colKhoangGiaTriViPham.FillWeight = 100F;
        colKhoangGiaTriViPham.HeaderText = "Khoảng nồng độ";
        colKhoangGiaTriViPham.MinimumWidth = 130;
        colKhoangGiaTriViPham.Name = "colKhoangGiaTriViPham";
        // 
        // colMucPhat
        // 
        colMucPhat.DataPropertyName = "MucPhat";
        colMucPhat.FillWeight = 90F;
        colMucPhat.HeaderText = "Mức phạt";
        colMucPhat.MinimumWidth = 115;
        colMucPhat.Name = "colMucPhat";
        // 
        // colMoTaViPham
        // 
        colMoTaViPham.DataPropertyName = "MoTa";
        colMoTaViPham.FillWeight = 170F;
        colMoTaViPham.HeaderText = "Mô tả";
        colMoTaViPham.MinimumWidth = 200;
        colMoTaViPham.Name = "colMoTaViPham";
        // 
        // CatalogForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = ColorTranslator.FromHtml("#F4F6F9");
        ClientSize = new Size(1130, 748);
        Controls.Add(rootLayout);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.None;
        Name = "CatalogForm";
        Text = "Danh mục";
        rootLayout.ResumeLayout(false);
        panelTabs.ResumeLayout(false);
        panelHost.ResumeLayout(false);
        panelLoaiPhuongTien.ResumeLayout(false);
        cardLoaiPhuongTien.ResumeLayout(false);
        panelHeaderLoaiPhuongTien.ResumeLayout(false);
        gridHostLoaiPhuongTien.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridLoaiPhuongTien).EndInit();
        panelMucNongDo.ResumeLayout(false);
        cardMucNongDo.ResumeLayout(false);
        panelHeaderMucNongDo.ResumeLayout(false);
        gridHostMucNongDo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridMucNongDo).EndInit();
        panelLoaiViPham.ResumeLayout(false);
        cardLoaiViPham.ResumeLayout(false);
        panelHeaderLoaiViPham.ResumeLayout(false);
        gridHostLoaiViPham.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridLoaiViPham).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout = null!;
    private Panel panelTabs = null!;
    private RoundedButton btnLoaiPhuongTien = null!;
    private RoundedButton btnMucNongDo = null!;
    private RoundedButton btnLoaiViPham = null!;
    private Label lblTabHint = null!;
    private Panel panelHost = null!;
    private Panel panelLoaiPhuongTien = null!;
    private RoundedPanel cardLoaiPhuongTien = null!;
    private Panel panelHeaderLoaiPhuongTien = null!;
    private Label lblTitleLoaiPhuongTien = null!;
    private Label lblHintLoaiPhuongTien = null!;
    private RoundedButton btnThemLoaiPhuongTien = null!;
    private Panel gridHostLoaiPhuongTien = null!;
    private BufferedDataGridView gridLoaiPhuongTien = null!;
    private DataGridViewTextBoxColumn colMaLoaiPhuongTien = null!;
    private DataGridViewTextBoxColumn colTenPhuongTien = null!;
    private DataGridViewTextBoxColumn colMoTaPhuongTien = null!;
    private Panel panelMucNongDo = null!;
    private RoundedPanel cardMucNongDo = null!;
    private Panel panelHeaderMucNongDo = null!;
    private Label lblTitleMucNongDo = null!;
    private Label lblHintMucNongDo = null!;
    private RoundedButton btnThemMucNongDo = null!;
    private Panel gridHostMucNongDo = null!;
    private BufferedDataGridView gridMucNongDo = null!;
    private DataGridViewTextBoxColumn colMaMucNongDo = null!;
    private DataGridViewTextBoxColumn colKhoangGiaTri = null!;
    private DataGridViewTextBoxColumn colNguongTren = null!;
    private DataGridViewTextBoxColumn colMoTaMucNongDo = null!;
    private Panel panelLoaiViPham = null!;
    private RoundedPanel cardLoaiViPham = null!;
    private Panel panelHeaderLoaiViPham = null!;
    private Label lblTitleLoaiViPham = null!;
    private Label lblHintLoaiViPham = null!;
    private RoundedButton btnThemLoaiViPham = null!;
    private Panel gridHostLoaiViPham = null!;
    private BufferedDataGridView gridLoaiViPham = null!;
    private DataGridViewTextBoxColumn colMaLoaiViPham = null!;
    private DataGridViewTextBoxColumn colTenLoaiViPham = null!;
    private DataGridViewTextBoxColumn colTenPhuongTienViPham = null!;
    private DataGridViewTextBoxColumn colKhoangGiaTriViPham = null!;
    private DataGridViewTextBoxColumn colMucPhat = null!;
    private DataGridViewTextBoxColumn colMoTaViPham = null!;
}
